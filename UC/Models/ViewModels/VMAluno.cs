using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMAluno
    {
        public long alunoUID { get; set; }
        public long turmaUID { get; set; }
        public string nome { get; set; }
        public bool situacaoRegular { get; set; }
        public VMTurma Turma { get; set; }
        public long pessoaUID { get; set; }

        public VMAluno()
        {
        }

        public VMAluno(Aluno aluno)
        {
            this.alunoUID = aluno.alunoUID;
            this.turmaUID = aluno.turmaUID;
            this.nome = aluno.Pessoa.nome;
            this.situacaoRegular = aluno.ativo;
            this.pessoaUID = aluno.pessoaUID;
        }

        public VMAluno(IUnityOfHelpers u, Aluno aluno)
        {
            this.alunoUID = aluno.alunoUID;
            this.turmaUID = aluno.turmaUID;
            this.nome = aluno.Pessoa.nome;
            this.situacaoRegular = aluno.ativo;
            this.pessoaUID = aluno.pessoaUID;

            this.Turma = new VMTurma(u, aluno);
        }
    }
}