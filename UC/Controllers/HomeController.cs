using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Index", "Index", new { Area = "Comum" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return Error();
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}