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
                var inicioDia = dia.HasValue ? dia.Value.Date : DateTime.Today;
                var fimDia = inicioDia.AddHours(23).AddMinutes(59);

                var listaExecucao = idbucContext.ExecucaoMetas.Where(x => 
                    x.ativo 
                    && x.Meta.usuarioUID == SimpleSessionPersister.usuarioUID 
                    && x.dataInicio < fimDia 
                    && x.dataTermino >= inicioDia).ToList();

                listaExecucao = listaExecucao.OrderBy(x => x.dataInicio).ToList();

                var execucoesPorId = listaExecucao.Select(x => x.execucaoMetaUID).ToList();

                var habitosDeHoje = idbucContext.HorariosHabito.Where(x =>
                    x.Ativo && !x.Finalizado 
                    && fimDia >= x.DataCriacao
                    && !x.ExecucaoMetas.Any(y => execucoesPorId.Contains(y.execucaoMetaUID))
                    && (x.cicloHabitoUID.HasValue && x.CicloHabito.ativo && x.CicloHabito.Habito.ativo && x.CicloHabito.Habito.Meta.ativo 
                        || x.diaSemanaHabitoUID.HasValue && x.DiaSemanaHabito.Ativo && x.DiaSemanaHabito.Habito.ativo && x.DiaSemanaHabito.Habito.Meta.ativo)
                    && (!x.diaSemanaHabitoUID.HasValue || x.diaSemanaHabitoUID.HasValue && x.DiaSemanaHabito.DiaSemana == (int)inicioDia.DayOfWeek)).ToList();

                var model = new VMListCronogramaDia(listaExecucao, habitosDeHoje, inicioDia);

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