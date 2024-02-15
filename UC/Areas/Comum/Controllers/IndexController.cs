using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {
            if (!SimpleSessionPersister.IsLogged)
            {
                return RedirectToAction("Login", "Home", new { Area = "" });
            }

            return View();
        }

        public ActionResult Banner()
        {
            AddMessage(UserMessageType.warning, "Dísponível nas próximas atualizações...");
            return Index();
        }
    }
}