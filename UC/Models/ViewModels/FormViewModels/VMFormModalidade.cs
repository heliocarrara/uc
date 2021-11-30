using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormModalidade
    {
        public long modalidadeUID { get; set; }
        public string Modalidade { get; set; }
        public string Descricao { get; set; }
        public double ValorInscrição { get; set; }
        public double ValorMensalidade { get; set; }
        public bool disponivel { get; set; }
        public bool ativa { get; set; }
        public int tipoModalidade { get; set; }

        public VMFormModalidade()
        {
            this.modalidadeUID = 0;
            this.ValorInscrição = 0;
            this.ValorMensalidade = 0;
            this.disponivel = false;
            this.tipoModalidade = 0;
            this.ativa = true;
        }

        public VMFormModalidade(ModalidadeSet modalidade)
        {
            this.modalidadeUID = modalidade.modalidadeUID;
            this.Modalidade = modalidade.Modalidade;
            this.tipoModalidade = modalidade.tipoModalidade;
            this.Descricao = modalidade.Descricao;
            this.ValorInscrição = modalidade.ValorInscrição;
            this.ValorMensalidade = modalidade.ValorMensalidade;
            this.disponivel = modalidade.disponivel;
        }
    }

    
}