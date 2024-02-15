using System;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;

namespace UC.Areas.Cadastro.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Home", new { Area = "" });
        }

        public ActionResult NovoCadastro()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        [HttpPost]
        public ActionResult GravarFormulario(Usuario form)
        {
            try
            {
                if (form == null)
                {
                    throw new Exception("Erro ao carregar form");
                }

                if (form.nome == null) { throw new Exception(); }
                if (form.senha == null) { throw new Exception(); }
                if (form.cpf == null) { throw new Exception(); }
                if (form.email == null) { throw new Exception(); }

                if(idbucContext.Usuarios.Any(x => x.cpf == form.cpf))
                {
                    throw new Exception("CPF já cadastrado");
                }

                form.dataCriacao = DateTime.Now;
                form.usuarioUID = form.usuarioUID < 0 ? 0 : form.usuarioUID;
                form.ativo = true;

                idbucContext.Usuarios.Add(form);

                idbucContext.SaveChanges();

                var chave = new ChaveAtivacao
                {
                    chaveAtivacaoUID = 0,
                    cpf = form.cpf,
                    email = form.email,
                    usuarioUID = form.usuarioUID,
                    tipoPermissao = (int)TipoLogin.Comum,
                    dataCriacao = DateTime.Now
                };

                idbucContext.ChavesAtivacao.Add(chave);

                idbucContext.SaveChanges();

                var permissao = new Permissao
                {
                    permissaoUID = 0,
                    ativo = true,
                    usuarioUID = form.usuarioUID,
                    tipoPermissao = (int)TipoLogin.Comum,
                    chaveAtivacaoUID = chave.chaveAtivacaoUID,
                    dataCriacao = DateTime.Now
                };

                idbucContext.Permissoes.Add(permissao);

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Cadastro Realizado.");

                return RedirectToAction("Login", "Home", new { Area = ""});

            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return NovoCadastro();
            }
        }
    }
}