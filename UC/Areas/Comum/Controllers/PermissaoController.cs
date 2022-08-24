using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.Enumerators;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Comum.Controllers
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
            try
            {
                var lista = idbucContext.Permissaos.Where(x => x.validade >= DateTime.Now).ToList();

                var model = new VMListPermissao(lista);

                ViewBag.Message = "Permissões";

                return View(viewLista, model);
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}