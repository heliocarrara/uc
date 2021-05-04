using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(string login, string senha)
        {

            return View("Index");
            //try
            //{
            //    throw new NotImplementedException("Login para estudantes no sistema ainda não está disponível.");
            //    //TENTATIVA DE LOGIN DE ESTUDANTE
            //    try
            //    {
            //        var aluno = unityOfHelpers.Services.Autenticacao.LoginEstudanteGeral(login, senha, tiposDeEstudantesSIEx);

            //        if (aluno != null)
            //        {
            //            throw new NotImplementedException("Login para estudantes no sistema ainda não está disponível.");

            //            SimpleSessionPersister.LoginEstudante(unityOfHelpers, aluno);

            //            return RedirectToAction("Index", "Index", new { Area = SimpleSessionPersister.UserRole });
            //        }
            //    }
            //    catch (NotImplementedException)
            //    { throw; }
            //    catch (Exception) { }

            //    //Tento logar como servidor (não uso try/catch porque é minha última opção de login).
            //    var usuario = unityOfHelpers.Services.Autenticacao.Login(login, senha);


            //    //Se não conseguiu logar, o serviço de auntenticação irá gerar uma exceção que vai cair no catch.

            //    return DirecionamentoDeLogin(usuario);
            //}
            //catch (Exception ex)
            //{
            //    SimpleSessionPersister.LogOut();
            //    AddMessage(UserMessageType.error, ex);
            //    return RedirectToAction("LogOn");
            //}
        }
    }
}