using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Professor.Controllers
{
    [System.Web.Http.Authorize(Roles = "Professor")]
    public class PainelController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Detalhes()
        {
            try
            {
                var pessoaUID = long.Parse(Utility.SimpleSessionPersister.Id);

                var professor = idbucContext.Professors.FirstOrDefault(x => x.ativo && x.pessoaUID == pessoaUID && x.validade > DateTime.Now);
                var model = new VMPainelProfessor(myUnityOfHelpers, professor);

                return View("DetalhesPainel", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}