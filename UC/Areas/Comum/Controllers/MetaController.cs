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
    public class MetaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }

        public ActionResult Lista()
        {
            try
            {
                var metas = idbucContext.Metas.Where(x => x.ativo).ToList();
                var model = new VMListMeta(myUnityOfHelpers, metas);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex.Message);
                return Index();
            }
        }

        public ActionResult Detalhes(long metaUID)
        {
            try
            {
                var meta = idbucContext.Metas.Find(metaUID);

                var model = new VMMeta(myUnityOfHelpers, meta);

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