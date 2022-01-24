using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormBolsista
    {
        public long? bolsistaUID { get; set; }
        public long? pessoaUID { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }

        public VMFormBolsista()
        {
        }

        public VMFormBolsista(Pessoa pessoa)
        {
            this.pessoaUID = pessoa.pessoaUID;
            this.cpf = pessoa.cpf;
            this.nome = pessoa.nome;
        }

        public VMFormBolsista(Bolsista bolsista)
        {
            this.bolsistaUID = bolsista.bolsistaUID;
            this.cpf = bolsista.Pessoa.cpf;
            this.pessoaUID = bolsista.pessoaUID;
            this.nome = bolsista.Pessoa.nome;        
        }
    }
}