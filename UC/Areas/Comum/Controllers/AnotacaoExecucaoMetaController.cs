using System;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class AnotacaoExecucaoMetaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }

        public ActionResult ListarAnotacoes(DateTime? dia)
        {
            var inicioDia = dia.HasValue ? dia.Value.Date : DateTime.Today;
            var fimDia = inicioDia.AddHours(23).AddMinutes(59);

            var listaAnotacoes = idbucContext.AnotacaoExecucaoMetas.Where(x =>
                x.ativo
                && x.ExecucaoMeta.ativo
                && x.ExecucaoMeta.Meta.ativo
                && x.ExecucaoMeta.Meta.usuarioUID == SimpleSessionPersister.usuarioUID
                && x.ExecucaoMeta.dataInicio < fimDia
                && x.ExecucaoMeta.dataTermino >= inicioDia).ToList();

            var model = new VMListAnotacao(myUnityOfHelpers, listaAnotacoes, inicioDia);

            return View(model);
        }
    }
}