using System;
using System.Web.Mvc;
using UC.Controllers;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class CicloHabitoController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }

        public ActionResult Detalhes(long cicloHabitoUID)
        {
            try
            {
                var ciclo = idbucContext.CiclosHabito.Find(cicloHabitoUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(ciclo.Habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                return View(ciclo);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex.Message);
                return Index();
            }
        }
    }
}