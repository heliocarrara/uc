using System;
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
        public ActionResult Detalhes()
        {
            try
            {
                var metas = idbucContext.Metas.Where(x => x.ativo).ToList();
                var model = new VMIndex(metas);

                return View(model);
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex.Message);
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
        }
    }
}