using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormProfessor
    {
        public long? professorUID { get; set; }
        public long? pessoaUID { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }

        public VMFormProfessor()
        {
        }

        public VMFormProfessor(Pessoa pessoa)
        {
            this.pessoaUID = pessoa.pessoaUID;
            this.cpf = pessoa.cpf;
            this.nome = pessoa.nome;
        }
    }
}