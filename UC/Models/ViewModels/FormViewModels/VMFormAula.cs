using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormAula
    {
        public long aulaUID { get; set; }
        public long turmaUID { get; set; }
        public bool aulaExtra { get; set; }
        public int duracaoMin { get; set; }
        public DateTime dataRealizacao { get; set; }

        public VMFormAula()
        {
        }

        public VMFormAula(Turma turma)
        {
            this.aulaUID = 0;
            this.turmaUID = turma.turmaUID;
            this.duracaoMin = (int)turma.DuracaoAula;
            this.dataRealizacao = new DateTime();
        }
        public VMFormAula(Aula aula)
        {
            this.aulaUID = aula.aulaUID;
            this.turmaUID = aula.turmaUID;
            this.duracaoMin = aula.duracaoMin;
            this.dataRealizacao = aula.dataRealizacao;
            this.aulaExtra = aulaExtra;
        }
    }
}