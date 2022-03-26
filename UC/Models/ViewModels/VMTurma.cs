using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.ViewModels.ListViewModels;

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
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public VMModalidade Modalidade { get; set; }
        public VMListAluno ListaAlunos { get; set; }
        public VMListAula ListaAula { get; set; }
        public VMListProfessorTurma ListaProfessoresTurma { get; set; }
        public VMListDiasDaSemana DiasDaSemana { get; set; }
        public bool disponivel { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMTurma()
        {

        }

        public VMTurma (IUnityOfHelpers u, Turma turma)
        {
            this.turmaUID = turma.turmaUID;
            this.HorarioInicio = turma.HorarioInicio;
            this.DuracaoAula = turma.DuracaoAula;
            this.Descricao = turma.Descricao;
            this.Vagas = turma.Vagas;

            this.HorarioTermino = this.HorarioInicio.AddMinutes(this.DuracaoAula);

            this.disponivel = turma.disponivel;
            this.Nome = u.Turmas.GetNomeTurma(turma);

            this.ListaAlunos = new VMListAluno(turma);
            this.Modalidade = new VMModalidade(turma);
            this.ListaProfessoresTurma = new VMListProfessorTurma(turma);
            this.ListaAula = new VMListAula(turma);
            this.DiasDaSemana = new VMListDiasDaSemana(u, turma);
        }

        public VMTurma(IUnityOfHelpers u, Aluno aluno)
        {
            this.turmaUID = aluno.Turma.turmaUID;
            this.HorarioInicio = aluno.Turma.HorarioInicio;
            this.DuracaoAula = aluno.Turma.DuracaoAula;
            this.Descricao = aluno.Turma.Descricao;
            this.HorarioTermino = this.HorarioInicio.AddMinutes(this.DuracaoAula);
            this.Nome = u.Turmas.GetNomeTurma(aluno.Turma);

            this.ListaAula = new VMListAula(aluno);
            this.Modalidade = new VMModalidade(aluno.Turma);
            this.DiasDaSemana = new VMListDiasDaSemana(u, aluno.Turma);
            this.ListaProfessoresTurma = new VMListProfessorTurma(aluno.Turma);
        }
        #endregion
    }
}