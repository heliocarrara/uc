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
    
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.LoginSet = new HashSet<Login>();
        }
    
        public long pessoaUID { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public System.DateTime nascimento { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public int nivelAcesso { get; set; }
    
        public virtual ICollection<Login> LoginSet { get; set; }
    }
}
