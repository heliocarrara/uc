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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.ChaveAtivacaos = new HashSet<ChaveAtivacao>();
            this.Permissaos = new HashSet<Permissao>();
        }
    
        public long usuarioUID { get; set; }
        public string cpf { get; set; }
        public string senha { get; set; }
        public string senhaSecundaria { get; set; }
        public string email { get; set; }
        public bool ativo { get; set; }
        public System.DateTime dataCriacao { get; set; }
    
        public virtual ICollection<ChaveAtivacao> ChaveAtivacaos { get; set; }
        public virtual ICollection<Permissao> Permissaos { get; set; }
    }
}
