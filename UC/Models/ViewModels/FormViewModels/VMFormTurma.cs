using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormTurma
    {
        public long? turmaUID { get; set; }
        public long modalidadeUID { get; set; }
        public bool disponivel { get; set; }
        public int horaInicio { get; set; }
        public int minutoInicio { get; set; }
        public int horaTermino { get; set; }
        public int minutoTermino { get; set; }
        public int vagas { get; set; }
        public string descricao { get; set; }

        public VMFormTurma()
        {
        }

        public VMFormTurma(long modalidadeUID)
        {
            this.modalidadeUID = modalidadeUID;
        }

        public VMFormTurma(Turma turma)
        {
            this.turmaUID = turma.turmaUID;
            this.modalidadeUID = turma.modalidadeUID;
            this.disponivel = turma.disponivel;
            this.horaInicio = turma.HorarioInicio.Hour;
            this.minutoInicio = turma.HorarioInicio.Minute;

            var termino = turma.HorarioInicio.AddMinutes(turma.DuracaoAula);

            this.horaTermino = termino.Hour;
            this.minutoTermino = termino.Minute;
            this.vagas = turma.Vagas;
            this.descricao = turma.Descricao;
        }
    }
}