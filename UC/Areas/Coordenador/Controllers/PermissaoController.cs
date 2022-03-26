using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.Enumerators;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class PermissaoController : BaseController
    {
        const string viewLista = "ListaPermissao";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Lista()
        {
            var lista = idbucContext.Permissaos.Where(x => x.validade >= DateTime.Now).ToList();

            var model = new VMListPermissao(lista);

            ViewBag.Message = "Permissões";

            return View(viewLista, model);
        }


        //public ActionResult Excluir(long permissaoUID)
        //{
        //    var permissao = idbucContext.Permissaos.Find(permissaoUID);

        //    if (permissao != null)
        //    {
        //        switch (permissao.tipoLogin)
        //        {
        //            case (int)TipoLogin.Professor:
        //                return RedirectToAction("Exluir", "Professor", new { Area = "Cadastro", alunoUID = 0 });
        //            case (int)TipoLogin.Aluno:
        //                return RedirectToAction("Exluir", "Professor", new { Area = "Cadastro", alunoUID = 0 });
        //            case (int)TipoLogin.Visitante:
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    AddMessage(UserMessageType.error, "Erro ao tentar excluir. Não é possível por aqui.");
        //    return Index();
        //}
    }
}