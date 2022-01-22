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
        public Modalidade Modalidade { get; set; }
        public List<VMAluno> Alunos { get; set; }
        public List<VMBolsista> Bolsistas { get; set; }
        public VMListDiasDaSemana DiasDaSemana { get; set; }
        public bool disponivel { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMTurma()
        {

        }

        public VMTurma (Turma turma)
        {
            this.turmaUID = turma.turmaUID;
            this.HorarioInicio = turma.HorarioInicio;
            this.DuracaoAula = turma.DuracaoAula;
            this.Descricao = turma.Descricao;
            this.Vagas = turma.Vagas;

            this.HorarioTermino = this.HorarioInicio.AddMinutes(this.DuracaoAula);
            this.Modalidade = turma.Modalidade;

            this.disponivel = turma.disponivel;
            this.Nome = turma.Modalidade.nome + " - " +turma.HorarioInicio.ToShortTimeString();

            this.Alunos = new List<VMAluno>();
            if (turma.Alunoes != null && turma.Alunoes.Any(x => x.ativo))
            {
                foreach (var cadaAluno in turma.Alunoes.Where(x => x.ativo).ToList())
                {
                    this.Alunos.Add(new VMAluno(cadaAluno));
                }
            }

            this.Bolsistas = new List<VMBolsista>();
            if (turma.Bolsistas != null && turma.Bolsistas.Any(x => x.ativo && x.validade > DateTime.Now))
            {
                foreach (var cadaBolsista in turma.Bolsistas.Where(x => x.ativo && x.validade > DateTime.Now).ToList())
                {
                    this.Bolsistas.Add(new VMBolsista(cadaBolsista));
                }
            }

            this.DiasDaSemana = new VMListDiasDaSemana(turma);
        }
        #endregion
    }
}