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
    
    public partial class Aula
    {
        public Aula()
        {
            this.AtividadeAulas = new HashSet<AtividadeAula>();
            this.Chamadas = new HashSet<Chamada>();
            this.JustificativaAulas = new HashSet<JustificativaAula>();
        }
    
        public long aulaUID { get; set; }
        public long diasemanaturmaUID { get; set; }
        public System.DateTime dataRealizacao { get; set; }
        public long turmaUID { get; set; }
        public bool ativa { get; set; }
        public bool aulaExtra { get; set; }
        public int duracaoMin { get; set; }
    
        public virtual ICollection<AtividadeAula> AtividadeAulas { get; set; }
        public virtual DiaSemanaTurma DiaSemanaTurma { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<Chamada> Chamadas { get; set; }
        public virtual ICollection<JustificativaAula> JustificativaAulas { get; set; }
    }
}