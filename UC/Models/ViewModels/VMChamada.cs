using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels
{
    public class VMChamada
    {
        public long chamadaUID { get; set; }
        public long alunoUID { get; set; }
        public long aulaUID { get; set; }
        public bool Presente { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public VMJustificativaAula justificativaAula { get; set; }

        public VMChamada()
        {

        }
        public VMChamada(Chamada chamada)
        {
            this.chamadaUID = chamada.chamadaUID;

            this.alunoUID = chamada.alunoUID;
            this.Nome = chamada.Aluno.Pessoa.nome;
            this.aulaUID = chamada.aulaUID;

            this.Presente = chamada.presente;
            this.Situacao = chamada.presente ? "Presente" : "Falta";

            if (!chamada.presente && chamada.JustificativaAulas.Any(x => x.ativa))
            {
                this.justificativaAula = new VMJustificativaAula(chamada.JustificativaAulas.FirstOrDefault(x => x.ativa));
            }
        }
    }
}