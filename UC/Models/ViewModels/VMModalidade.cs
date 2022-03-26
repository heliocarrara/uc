using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Models.ViewModels
{
    public class VMModalidade
    {
        #region PROPERTIES
        public long modalidadeUID { get; set; }
        public long tipoModalidade { get; set; }
        public string nome { get; set; }
        public string Descricao { get; set; }
        public VMListTurma ListaTurma { get; set; }
        public string ValorInscrição { get; set; }
        public string ValorMensalidade { get; set; }

        public bool ativa { get; set; }
        public bool disponivel { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMModalidade()
        {

        }

        public VMModalidade(IUnityOfHelpers u, Modalidade modalidade)
        {
            this.modalidadeUID = modalidade.modalidadeUID;
            this.tipoModalidade = modalidade.tipoModalidade;
            this.nome = modalidade.nome;
            this.Descricao = modalidade.Descricao;
            this.ValorInscrição = "R$" + modalidade.ValorInscrição + ",00";
            this.ValorMensalidade = "R$" + modalidade.ValorMensalidade + ",00";
            this.ativa = modalidade.ativa;
            this.disponivel = modalidade.disponivel;

            this.ListaTurma = new VMListTurma (u, modalidade);
        }

        public VMModalidade(Turma turma)
        {
            this.modalidadeUID = turma.Modalidade.modalidadeUID;
            this.tipoModalidade = turma.Modalidade.tipoModalidade;
            this.nome = turma.Modalidade.nome;
            this.Descricao = turma.Modalidade.Descricao;
            this.ValorInscrição = "R$" + turma.Modalidade.ValorInscrição + ",00";
            this.ValorMensalidade = "R$" + turma.Modalidade.ValorMensalidade + ",00";
        }
        #endregion


    }
}