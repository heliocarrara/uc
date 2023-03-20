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

namespace UC.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index", new { Area = "Comum"});
        }
    }
}