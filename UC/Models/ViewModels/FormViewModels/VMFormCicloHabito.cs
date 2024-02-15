using System.Web.Mvc;
using System;
using Org.BouncyCastle.Asn1.Cms;
using System.Linq;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormCicloHabito
    {
        public long cicloHabitoUID { get; set; }
        public long habitoUID { get; set; }
        public long horarioHabitoUID { get; set; }
        public int TipoCiclo { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }
        public int? DiaSemanal { get; set; }
        public SelectList ListaTipoCiclo { get; set; }
        public SelectList ListaDiaSemanal { get; set; }

        public VMFormCicloHabito()
        {
        }

        public VMFormCicloHabito(IUnityOfHelpers u, Habito habito)
        {
            this.habitoUID = habito.habitoUID;

            this.ListaTipoCiclo = u.SelectLists.TipoCicloHabito(null);
            this.ListaDiaSemanal = u.SelectLists.DiasDaSemana(null);

            this.HorarioInicio = new TimeSpan(DateTime.Now.Ticks);
            this.HorarioTermino = new TimeSpan(DateTime.Now.AddHours(1).Ticks);
        }
        public VMFormCicloHabito(IUnityOfHelpers u, CicloHabito cicloHabito) : this(u, cicloHabito.Habito)
        {
            this.cicloHabitoUID = cicloHabito.cicloHabitoUID;
        }
        public VMFormCicloHabito(IUnityOfHelpers u, HorarioHabito horarioHabito)
        {
            this.habitoUID = horarioHabito.CicloHabito.habitoUID;
            this.cicloHabitoUID = horarioHabito.CicloHabito.cicloHabitoUID;
            this.horarioHabitoUID = horarioHabito.horarioHabitoUID;
            this.DiaSemanal = horarioHabito.diaSemanaHabitoUID.HasValue ? horarioHabito.DiaSemanaHabito.DiaSemana : (int?)null;

            this.ListaTipoCiclo = u.SelectLists.TipoCicloHabito(horarioHabito.CicloHabito.TipoCiclo);
            this.ListaDiaSemanal = u.SelectLists.DiasDaSemana(this.DiaSemanal);

            this.HorarioInicio = horarioHabito.HorarioInicio;
            this.HorarioTermino = horarioHabito.HorarioTermino;
            this.TipoCiclo = horarioHabito.CicloHabito.TipoCiclo;
        }
    }
}