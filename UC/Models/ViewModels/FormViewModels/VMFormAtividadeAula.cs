using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormAtividadeAula
    {
        public long? atividadeaulaUID { get; set; }
        public long aulaUID { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int duracaoMin { get; set; }

        public VMFormAtividadeAula()
        {
        }
        public VMFormAtividadeAula(Aula aula)
        {
            this.aulaUID = aula.aulaUID;
        }
        public VMFormAtividadeAula(AtividadeAula atividadeAulas)
        {
            this.atividadeaulaUID = atividadeAulas.atividadeaulaUID;
            this.aulaUID = atividadeAulas.aulaUID;
            this.titulo = atividadeAulas.titulo;
            this.descricao = atividadeAulas.descricao;
            this.duracaoMin = atividadeAulas.duracaoMin;
        }
    }
}