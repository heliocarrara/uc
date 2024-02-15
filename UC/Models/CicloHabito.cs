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
    
    public partial class CicloHabito
    {
        public CicloHabito()
        {
            this.HorariosHabito = new HashSet<HorarioHabito>();
        }
    
        public long cicloHabitoUID { get; set; }
        public long habitoUID { get; set; }
        public bool ativo { get; set; }
        public bool finalizado { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public int TipoCiclo { get; set; }
        public Nullable<int> DiaMes { get; set; }
        public Nullable<int> MesAno { get; set; }
    
        public virtual Habito Habito { get; set; }
        public virtual ICollection<HorarioHabito> HorariosHabito { get; set; }
    }
}
