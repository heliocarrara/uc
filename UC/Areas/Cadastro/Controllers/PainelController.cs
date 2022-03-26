using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UC.Controllers;

namespace UC.Areas.Cadastrontrollers
{
    public class PainelController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Detalhes()
        {
            if (Utility.SimpleSessionPersister.IsLogged)
            {
                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }

            return Index();
        }
    }
}