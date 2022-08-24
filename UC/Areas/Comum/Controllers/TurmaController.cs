using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Comum.Controllers
{
    public class TurmaController : BaseController
    {
        public ActionResult Index()
        {
            if (Utility.SimpleSessionPersister.IsLogged)
            {
                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }

            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Detalhes(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                var model = new VMTurma(myUnityOfHelpers, turma);

                ViewBag.Message = "Detalhes Turma";

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }


        public ActionResult Lista()
        {
            try
            {
                var turma = idbucContext.Turmas.Where(x => x.ativa && x.disponivel).ToList();

                var model = new VMListTurma(myUnityOfHelpers, turma);

                ViewBag.Message = "Turmas";

                return View("ListaTurma", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Lixeira()
        {
            try
            {
                var turma = idbucContext.Turmas.Where(x => !x.ativa || !x.disponivel).ToList();

                var model = new VMListTurma(myUnityOfHelpers, turma);

                ViewBag.Message = "Turmas desativadas";

                return View("ListaTurma", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}
