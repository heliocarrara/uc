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
                var usuario = idbucContext.LoginSet.FirstOrDefault(x => x.login == cpf);

                if (usuario == null)
                {
                    throw new Exception("Cadastro não encontrado.");
                }

                if (usuario.validade < hoje)
                {
                    usuario = idbucContext.LoginSet.FirstOrDefault(x => x.login == cpf && x.validade >= hoje);

                    if (usuario == null)
                    {
                        throw new Exception("Login Expirado.");
                    }
                }

                if (usuario.senha != senha)
                {
                    throw new Exception("Senha Incorreta.");
                }
                var pessoa = myUnityOfHelpers.idbucContext.PessoaSet.Find(usuario.pessoaUID);

                SimpleSessionPersister.Logar(pessoa);

                return RedirectToAction("Detalhes", "Painel", new { Area = UC.Utility.SimpleSessionPersister.UserRole });
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
                var users = myUnityOfHelpers.idbucContext.LoginSet.Where(x => x.loginUID >= 0).ToList();

                var pessoas = myUnityOfHelpers.idbucContext.PessoaSet.Where(x => x.pessoaUID >= 0).ToList();

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
                var pessoa = new Pessoa
                {
                    pessoaUID = 0,
                    nome = form.nome,
                    cpf = form.cpf,
                    nascimento = form.nascimento,
                    endereco = form.cep,
                    telefone = form.telefone,
                    nivelAcesso = (int)TipoLogin.Coordenador
                };

                myUnityOfHelpers.idbucContext.PessoaSet.Add(pessoa);

                myUnityOfHelpers.idbucContext.SaveChanges();

                var usuario = new Login {
                    loginUID = 0,
                    login = form.email,
                    senha = form.senha,
                    validade = DateTime.Now.AddDays(365),
                    pessoaUID = pessoa.pessoaUID
                };

                myUnityOfHelpers.idbucContext.LoginSet.Add(usuario);

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