using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormModalidade
    {
        public SelectList ListaTiposDeModalidade { get; set; }
        public long modalidadeUID { get; set; }
        public string nome { get; set; }
        public string Descricao { get; set; }
        public double ValorInscrição { get; set; }
        public double ValorMensalidade { get; set; }
        public bool disponivel { get; set; }
        public bool ativa { get; set; }
        public int? tipoModalidade { get; set; }

        public VMFormModalidade()
        {
        }

        public VMFormModalidade(IUnityOfHelpers u)
        {
            this.modalidadeUID = 0;
            this.ValorInscrição = 0;
            this.ValorMensalidade = 0;
            this.disponivel = false;
            this.ativa = true;
            this.ListaTiposDeModalidade = u.SelectLists.TiposDeModalidade(null);
        }

        public VMFormModalidade(IUnityOfHelpers u,Modalidade modalidade)
        {
            this.modalidadeUID = modalidade.modalidadeUID;
            this.nome = modalidade.nome;
            this.Descricao = modalidade.Descricao;
            this.ValorInscrição = modalidade.ValorInscrição;
            this.ValorMensalidade = modalidade.ValorMensalidade;
            this.disponivel = modalidade.disponivel;
            this.ListaTiposDeModalidade = u.SelectLists.TiposDeModalidade(modalidade.tipoModalidade);
        }
    }

    
}