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
    
    public partial class RegistroSituacaoExecucaoMeta
    {
        public long registroSituacaoExecucaoMetaUID { get; set; }
        public long execucaoMetaUID { get; set; }
        public int situacaoPasso { get; set; }
        public bool ativo { get; set; }
        public string descricao { get; set; }
        public System.DateTime dataCriacao { get; set; }
    
        public virtual ExecucaoMeta ExecucaoMeta { get; set; }
    }
}