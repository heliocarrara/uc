using System;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class HabitoController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }

        public ActionResult Lista()
        {
            try
            {
                var habitos = idbucContext.Habitos.Where(x => x.ativo && !x.finalizado && x.Meta.ativo && x.Meta.usuarioUID == SimpleSessionPersister.usuarioUID && x.Meta.dataObjetivo >= DateTime.Today).ToList();
                var model = new VMListHabito(habitos);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex.Message);
                return Index();
            }
        }

        public ActionResult Detalhes(long habitoUID)
        {
            try
            {
                var habito = idbucContext.Habitos.Find(habitoUID);

                var model = new VMHabito(myUnityOfHelpers, habito);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex.Message);
                return Index();
            }
        }
    }
}