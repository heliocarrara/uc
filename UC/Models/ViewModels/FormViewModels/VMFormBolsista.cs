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
        public long? turmaUID { get; set; }
        public SelectList TurmasDisponiveis { get; set; }

        public VMFormBolsista()
        {
        }

        public VMFormBolsista(IUnityOfHelpers u)
        {
            this.TurmasDisponiveis = u.SelectLists.TurmasDisponiveis(null);
        }

        public VMFormBolsista(IUnityOfHelpers u, Pessoa pessoa, long? turmaUID)
        {
            this.TurmasDisponiveis = u.SelectLists.TurmasDisponiveis(null);
            this.turmaUID = turmaUID;
            this.pessoaUID = pessoa.pessoaUID;
            this.cpf = pessoa.cpf;
            this.nome = pessoa.nome;
        }

        public VMFormBolsista(Bolsista bolsista, IUnityOfHelpers u)
        {
            this.bolsistaUID = bolsista.bolsistaUID;
            this.cpf = bolsista.Pessoa.cpf;
            this.pessoaUID = bolsista.pessoaUID;
            this.TurmasDisponiveis = u.SelectLists.TurmasDisponiveis(bolsista.turmaUID);
            this.turmaUID = bolsista.turmaUID;
            this.nome = bolsista.Pessoa.nome;        }
    }
}