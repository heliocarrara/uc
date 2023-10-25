using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UC.Utility;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormBuscaAtividadeFixa
    {
        public AtividadeFixa Atividade { get; set; }
        public SelectList ListaMeta { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }

        public bool BuscarDisponiveis { get; set; }
        public bool AteDiaUtil { get; set; }

        public List<AtividadeFixa> ListaAtividadeFixa { get; set; }

        public VMFormBuscaAtividadeFixa()
        {
        }

        public VMFormBuscaAtividadeFixa(IUnityOfHelpers u)
        {
            this.ListaMeta = u.SelectLists.MetasPorUsuario(null);

            this.Atividade = new AtividadeFixa();
        }
        public VMFormBuscaAtividadeFixa(IUnityOfHelpers u, List<AtividadeFixa> atividades) : this(u)
        {
            this.ListaAtividadeFixa = atividades;
        }
    }
}