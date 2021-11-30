using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UC.Controllers;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class PainelController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Detalhes()
        {
            //Pega a pessoa, cargo
            //modalidades
            //turmas
            //pessoa


            return View("DetalhesPainel");
        }
    }
}