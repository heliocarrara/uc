using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Bolsista.Controllers
{
    [System.Web.Http.Authorize(Roles = "Bolsista")]
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

                var turmas = idbucContext.Turmas.Where(x => x.ativa && x.Bolsistas.Any(y => y.ativo && y.pessoaUID == pessoaUID && y.validade > DateTime.Now)).ToList();
                var model = new VMListTurma(turmas);

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