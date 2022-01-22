using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels
{
    public class VMModalidade
    {
        #region PROPERTIES
        public long modalidadeUID { get; set; }
        public long tipoModalidade { get; set; }
        public string nome { get; set; }
        public string Descrição { get; set; }
        public List<VMTurma> Turmas { get; set; }
        public string ValorInscrição { get; set; }
        public string ValorMensalidade { get; set; }

        public bool ativa { get; set; }
        public bool disponivel { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMModalidade()
        {

        }

        public VMModalidade(Modalidade modalidade)
        {
            this.modalidadeUID = modalidade.modalidadeUID;
            this.tipoModalidade = modalidade.tipoModalidade;
            this.nome = modalidade.nome;
            this.Descrição = modalidade.Descricao;
            this.ValorInscrição = "R$" + modalidade.ValorInscrição + ",00";
            this.ValorMensalidade = "R$" + modalidade.ValorMensalidade + ",00";
            this.ativa = modalidade.ativa;
            this.disponivel = modalidade.disponivel;

            this.Turmas = new List<VMTurma>();

            if (modalidade.Turmas != null && modalidade.Turmas.Any())
            {
                foreach (var cadaTurma in modalidade.Turmas.ToList())
                {
                    this.Turmas.Add(new VMTurma(cadaTurma));
                }
            }
        }
        #endregion

        
    }
}