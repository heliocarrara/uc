using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Comum.Controllers
{
    public class TurmaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Detalhes(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                var model = new VMTurma(turma);

                ViewBag.Message = "Detalhes Turma";

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
