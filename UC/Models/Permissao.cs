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
    
    public partial class Permissao
    {
        public long permissaoUID { get; set; }
        public long pessoaUID { get; set; }
        public int tipoLogin { get; set; }
        public System.DateTime dataCriacao { get; set; }
        public System.DateTime validade { get; set; }
    
        public virtual Pessoa Pessoa { get; set; }
    }
}