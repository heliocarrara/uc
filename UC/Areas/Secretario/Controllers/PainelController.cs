using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UC.Controllers;

namespace UC.Areas.Secretario.Controllers
{
    public class PainelController : BaseController
    {
        public ActionResult Detalhes()
        {
            return View("DetalhesPainel");
        }
    }
}