//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Turma
    {
        public Turma()
        {
            this.Alunoes = new HashSet<Aluno>();
            this.Aulas = new HashSet<Aula>();
            this.DiaSemanaTurmas = new HashSet<DiaSemanaTurma>();
            this.ProfessorTurmas = new HashSet<ProfessorTurma>();
        }
    
        public long turmaUID { get; set; }
        public long modalidadeUID { get; set; }
        public bool ativa { get; set; }
        public System.DateTime HorarioInicio { get; set; }
        public double DuracaoAula { get; set; }
        public string Descricao { get; set; }
        public int Vagas { get; set; }
        public bool disponivel { get; set; }
    
        public virtual ICollection<Aluno> Alunoes { get; set; }
        public virtual ICollection<Aula> Aulas { get; set; }
        public virtual ICollection<DiaSemanaTurma> DiaSemanaTurmas { get; set; }
        public virtual Modalidade Modalidade { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurmas { get; set; }
    }
}
