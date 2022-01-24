using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Models.ViewModels
{
    public class VMAula
    {
        public long aulaUID { get; set; }
        public DateTime diaAula { get; set; }
        public long turmaUID { get; set; }
        public VMListChamada ListaChamada { get; set; }
        public VMListAtividadeAula ListaAtividadeAula { get; set; }

        public VMAula()
        {
        }

        public VMAula(Aula aula)
        {
            this.aulaUID = aula.aulaUID;
            this.turmaUID = aula.turmaUID;
            this.diaAula = aula.dataRealizacao;

            this.ListaChamada = new VMListChamada(aula);
            this.ListaAtividadeAula = new VMListAtividadeAula(aula);
        }
    }
}