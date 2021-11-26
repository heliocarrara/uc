using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMTurma
    {
        #region PROPERTIES
        public long turmaUID { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
        public double DuracaoAula { get; set; }
        public string Descricao { get; set; }
        public int Vagas { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMTurma()
        {

        }

        public VMTurma (TurmaSet turma)
        {
            this.turmaUID = turma.turmaUID;
            this.HorarioInicio = turma.HorarioInicio;
            this.DuracaoAula = turma.DuracaoAula;
            this.Descricao = turma.Descricao;
            this.Vagas = turma.Vagas;

            this.HorarioTermino = this.HorarioInicio.AddMinutes(this.DuracaoAula);
        }
        #endregion
    }
}