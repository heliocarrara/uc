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
    
    public partial class Coordenador
    {
        public long coordenadorUID { get; set; }
        public bool ativo { get; set; }
        public long pessoaUID { get; set; }
    
        public virtual Pessoa Pessoa { get; set; }
    }
}
