using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class BolsistaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel");
        }

        public ActionResult Lista()
        {
            try
            {
                var model = new List<VMBolsista>();

                var bolsistas = idbucContext.Bolsistas.Where(x => x.ativo).ToList();

                foreach (var cadaBolsista in bolsistas)
                {
                    model.Add(new VMBolsista(cadaBolsista));
                }

                ViewBag.Message = "Bolsistas";

                return View("ListaBolsistas", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}