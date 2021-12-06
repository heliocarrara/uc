using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormAluno
    {
        public long alunoUID { get; set; }
        public string cpf { get; set; }
        public SelectList turmas { get; set; }
        public long? turmaUID { get; set; }
        public long? pessoaUID { get; set; }
        public string nome { get; set; }

        public VMFormAluno()
        {
        }
        public VMFormAluno(IUnityOfHelpers u)
        {
            this.alunoUID = 0;
            this.turmas = u.SelectLists.TurmasDisponiveis(null);
        }

        public VMFormAluno(IUnityOfHelpers u, long turmaUID)
        {
            this.alunoUID = 0;
            this.turmas = u.SelectLists.TurmasDisponiveis(turmaUID);
        }

        public VMFormAluno(IUnityOfHelpers u, Pessoa pessoa, long? turmaUID)
        {
            this.alunoUID = 0;
            this.turmas = u.SelectLists.TurmasDisponiveis(turmaUID);
            this.nome = pessoa.nome;
            this.cpf = pessoa.cpf;
            this.pessoaUID = pessoa.pessoaUID;
        }

        public VMFormAluno(IUnityOfHelpers u, long alunoUID, string cpf, long turmaUID)
        {
            this.alunoUID = alunoUID;
            this.cpf = cpf;
            this.turmaUID = turmaUID;
            this.turmas = u.SelectLists.TurmasDisponiveis(turmaUID);
        }
    }
}