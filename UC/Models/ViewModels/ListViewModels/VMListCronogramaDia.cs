using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListCronogramaDia
    {
        public List<VMCronograma> AtividadesDoDia { get; set; }
        public DateTime Dia { get; set; }

        public VMListCronogramaDia()
        {
        }

        public VMListCronogramaDia(List<ExecucaoMeta> atividadesDoDia, List<HorarioHabito> horariosHabito, DateTime dia)
        {
            AtividadesDoDia = new List<VMCronograma>();
            Dia = dia;

            foreach(var cadaAtividade in atividadesDoDia)
            {
                AtividadesDoDia.Add(new VMCronograma(cadaAtividade));
            }

            foreach(var cadaHorario in horariosHabito)
            {
                AtividadesDoDia.Add(new VMCronograma(cadaHorario, dia));
            }

            this.AtividadesDoDia = this.AtividadesDoDia.OrderBy(x => x.dataInicio).ToList();
        }
    }
}