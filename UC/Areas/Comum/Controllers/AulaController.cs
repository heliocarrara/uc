using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Comum.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class AulaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Detalhes(long aulaUID)
        {
            try
            {
                var aula = idbucContext.Aulas.Find(aulaUID);

                var model = new VMAula(aula);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}