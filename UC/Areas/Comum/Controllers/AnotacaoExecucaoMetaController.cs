using System.Web.Mvc;
using UC.Controllers;

namespace UC.Areas.Comum.Controllers
{
    public class AnotacaoExecucaoMetaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }
    }
}