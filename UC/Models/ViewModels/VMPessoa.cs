using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMPessoa
    {
        #region PROPERTIES
        public long pessoaUID { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string nascimento { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        #endregion

        #region CONSTRUCTORS
        public VMPessoa()
        {
        }

        public VMPessoa(Pessoa pessoa)
        {
            this.pessoaUID = pessoa.pessoaUID;
            this.nome = pessoa.nome;
            this.cpf = pessoa.cpf;
            this.nascimento = pessoa.nascimento.ToShortDateString();
            this.endereco = pessoa.endereco;
            this.telefone = pessoa.telefone;
        }
        #endregion
    }
}