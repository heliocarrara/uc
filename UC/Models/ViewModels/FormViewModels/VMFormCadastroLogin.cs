using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormCadastroLogin
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime nascimento { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }

        public VMFormCadastroLogin()
        {
            this.nascimento = DateTime.Today;
        }

        public VMFormCadastroLogin(string nome, string cpf, string senha, DateTime nascimento, string cep, string telefone)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.senha = senha;
            this.nascimento = nascimento;
            this.cep = cep;
            this.telefone = telefone;
        }
    }
}