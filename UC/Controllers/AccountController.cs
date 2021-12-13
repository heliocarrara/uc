using UC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models.ViewModels.FormViewModels;
using UC.Models.ViewModels.ListViewModels;
using UC.Utility;
using UC.Models.UCEntityHelpers;
using UC.Models.Enumerators;
using UC.Models.ViewModels;

namespace UC.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        public ActionResult Login(string cpf, string senha)
        {
            try
            {
                var hoje = DateTime.Now;
                var usuario = idbucContext.Logins.FirstOrDefault(x => x.usuario == cpf);

                if (usuario == null)
                {
                    throw new Exception("Cadastro não encontrado.");
                }

                if (usuario.validade < hoje)
                {
                    usuario = idbucContext.Logins.FirstOrDefault(x => x.usuario == cpf && x.validade > hoje);

                    if (usuario == null)
                    {
                        throw new Exception("Login Expirado.");
                    }
                }

                if (usuario.senha != senha)
                {
                    throw new Exception("Senha Incorreta.");
                }
                var pessoa = myUnityOfHelpers.idbucContext.Pessoas.Find(usuario.pessoaUID);

                SimpleSessionPersister.Logar(pessoa);

                return SelecionarPerfil();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult LogOut()
        {
            try
            {
                SimpleSessionPersister.LogOut();
                AddMessage(UserMessageType.info, "Login encerrado.");

                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult MudarPermissao (long permissaoUID)
        {
            try
            {
                var permissao = idbucContext.Permissaos.Find(permissaoUID);

                if (permissao == null)
                {
                    throw new Exception("Permissão não existe.");
                }

                if (permissao.validade < DateTime.Today)
                {
                    throw new Exception("Permissão expirada.");
                }

                if (permissao.pessoaUID.ToString() != SimpleSessionPersister.Id)
                {
                    throw new Exception("Esta permissão não é sua.");
                }

                SimpleSessionPersister.LogarComPermissao(permissao);

                return RedirectToAction("Detalhes", "Painel", new { Area = UC.Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult SelecionarPerfil()
        {
            try
            {
                var model = new List<VMPermissao>();
                var pessoaUID = long.Parse(SimpleSessionPersister.Id);

                var permissoes = idbucContext.Permissaos.Where(x => x.pessoaUID == pessoaUID && x.validade > DateTime.Now).ToList();

                foreach(var cadaPermissao in permissoes)
                {
                    model.Add(new VMPermissao(cadaPermissao, myUnityOfHelpers));
                }

                return View("SelecionarPermissao", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult NovoCadastro()
        {
            try
            {
                var model = new VMFormCadastroLogin();

                return View ("CadastroLogin", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult VerCadastros()
        {
            try
            {
                var users = myUnityOfHelpers.idbucContext.Logins.Where(x => x.loginUID >= 0).ToList();

                var pessoas = myUnityOfHelpers.idbucContext.Pessoas.Where(x => x.pessoaUID >= 0).ToList();

                var model = new VMListUsuarios(pessoas, users);

                return View("ListarUsuarios", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult CadastroLogin(VMFormCadastroLogin form) 
        {
            try
            {
                var cadastro = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == form.cpf);

                if (cadastro != null)
                {
                    AddMessage(UserMessageType.error, "Este CPF já tem cadastro sistema.");
                    return RedirectToAction("Login", "Home", "");
                }

                var pessoa = new Pessoa
                {
                    pessoaUID = 0,
                    nome = form.nome,
                    cpf = form.cpf,
                    nascimento = form.nascimento,
                    endereco = form.cep,
                    telefone = form.telefone,
                    nivelAcesso = (int)TipoLogin.Visitante
                };

                myUnityOfHelpers.idbucContext.Pessoas.Add(pessoa);

                myUnityOfHelpers.idbucContext.SaveChanges();

                var usuario = new Login {
                    loginUID = 0,
                    usuario = form.email,
                    senha = form.senha,
                    validade = DateTime.Now.AddDays(365),
                    pessoaUID = pessoa.pessoaUID
                };

                myUnityOfHelpers.idbucContext.Logins.Add(usuario);

                myUnityOfHelpers.idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, form.nome + " seu cadastro foi realizado com sucesso, já pode fazer login!");
                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}