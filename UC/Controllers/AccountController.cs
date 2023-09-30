using UC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Utility;
using UC.Models.UCEntityHelpers;
using UC.Models.Enumerators;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

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
                var usuario = idbucContext.Usuarios.FirstOrDefault(x => x.ativo && x.cpf == cpf && x.senha == senha);

                if(usuario == null)
                {
                    throw new Exception("Usuário não encontrado. Ctz que tem conta aqui?");
                }

                if(!usuario.Permissaos.Any(x => x.ativo))
                {
                    throw new Exception("Usuário sem permissão para acesso. Cade o convite?");
                }

                SimpleSessionPersister.LoginUsuario(usuario);

                AddMessage(UserMessageType.success, "Seja bem vind@ de volta!");

                return RedirectToAction("Index", "Index", new { Area = SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult ListaUsuario()
        {
            try
            {
                var listaUsuarios = idbucContext.Usuarios.Where(x => x.ativo).ToList();

                if (!listaUsuarios.Any())
                {
                    throw (new Exception("Usuário não encontrado. Ctz que tem conta aqui?"));
                }

                var model = new VMListUsuario(listaUsuarios);

                return View("ListaUsuario", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}