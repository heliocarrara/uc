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
    
    public partial class AtividadeFixa
    {
        public AtividadeFixa()
        {
            this.ExecucaoMetas = new HashSet<ExecucaoMeta>();
        }
    
        public long atividadeFixaUID { get; set; }
        public bool ativa { get; set; }
        public System.DateTime dataCriacao { get; set; }
        public int situacao { get; set; }
        public long metaUID { get; set; }
        public bool ateDiaUtil { get; set; }
        public System.DateTime horarioInicio { get; set; }
        public System.DateTime horarioFim { get; set; }
        public int ciclo { get; set; }
        public string nome { get; set; }
    
        public virtual ICollection<ExecucaoMeta> ExecucaoMetas { get; set; }
    }
}
