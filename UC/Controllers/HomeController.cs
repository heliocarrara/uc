using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Detalhes", "Index", new { Area = "Comum" });
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return View();
            }
        }
    }
}