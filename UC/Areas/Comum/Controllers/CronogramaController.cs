using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class CronogramaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }
        public ActionResult DetalharDia(DateTime? dia)
        {
            try
            {
                var dataInicio = dia.HasValue ? dia.Value : DateTime.Today;

                var proxDia = dataInicio.AddDays(1);

                var listaExecucao = idbucContext.ExecucaoMetas.Where(x => x.ativo && x.Meta.usuarioUID == SimpleSessionPersister.usuarioUID && x.dataInicio < proxDia && x.dataTermino >= dataInicio).ToList();

                listaExecucao = listaExecucao.OrderBy(x => x.dataInicio).ToList();

                var model = new VMListExecucaoMeta(listaExecucao, dataInicio);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult BuscarDia()
        {
            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return DetalharDia(null);
            }
        }
    }
}