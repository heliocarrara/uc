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
    
    public partial class ProfessorTurma
    {
        public long professorturmaUID { get; set; }
        public long turmaUID { get; set; }
        public long professorUID { get; set; }
        public bool ativo { get; set; }
        public System.DateTime dataCriacao { get; set; }
        public System.DateTime validade { get; set; }
    
        public virtual Professor Professor { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
