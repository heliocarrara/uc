﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Comum.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}