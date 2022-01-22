using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMAluno
    {
        public long alunoUID { get; set; }
        public string nome { get; set; }
        public Turma turma { get; set; }

        public VMAluno()
        {
        }

        public VMAluno(Aluno aluno)
        {
            this.alunoUID = aluno.alunoUID;
            this.nome = aluno.Pessoa.nome;
            this.turma = aluno.Turma;
        }
    }
}