using System;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class TurmaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel");
        }

        public ActionResult Detalhes(long turmaUID)
        {
            return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID});
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
                var turma = idbucContext.Turmas.Where(x => x.ativa == false || x.disponivel == false).ToList();

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