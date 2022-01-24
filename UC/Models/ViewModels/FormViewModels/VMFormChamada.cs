using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormChamada
    {
        public long? chamadaUID { get; set; }
        public long alunoUID { get; set; }
        public bool presenca { get; set; }
        public string nomeAluno { get; set; }
        public CheckBoxList lista { get; set; }

        public VMFormChamada()
        {
        }

        public VMFormChamada(Aluno aluno, Aula aula)
        {
            this.alunoUID = aluno.alunoUID;
            this.presenca = false;
            this.nomeAluno = aluno.Pessoa.nome;
        }

        public VMFormChamada(Chamada chamada)
        {
            this.alunoUID = chamada.alunoUID;
            this.presenca = chamada.presente;
            this.nomeAluno = chamada.Aluno.Pessoa.nome;
            this.chamadaUID = chamada.chamadaUID;
        }
    }
}