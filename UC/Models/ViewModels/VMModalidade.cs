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

        public VMModalidade(Modalidade modalidade, List<Turma> turmas)
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

            if (turmas != null && turmas.Any())
            {
                foreach (var cadaTurma in turmas)
                {
                    this.Turmas.Add(new VMTurma(cadaTurma));
                }
            }
            

            //switch (tipoModalidadeUID)
            //{
            //    case ((int)TipoModalidade.Hidroginastica):
            //        this.Modalidade = "Hidroginástica";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Treinamento_Funcional):
            //        this.Modalidade = "Treinamento Funcional";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Natacao):
            //        this.Modalidade = "Natação";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Muay_Thay):
            //        this.Modalidade = "Muay Thay Fitness";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Ritmos):
            //        this.Modalidade = "Ritmos";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Bale):
            //        this.Modalidade = "Balé Clássico";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Submission):
            //        this.Modalidade = "Submission No Gi";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$80,00";
            //        break;
            //    case ((int)TipoModalidade.Futebol_de_Campo):
            //        this.Modalidade = "Futebol de Campo";
            //        this.Descrição = "";
            //        this.ValorMensalidade = "R$25,00";
            //        break;
            //    default:
            //        this.Modalidade = "Erro";
            //        this.Descrição = "Erro";
            //        this.ValorMensalidade = "Erro";
            //        break;
            //}

            //var turmas = u.idbucContext.TurmaSet.Where(x => x.ativa && x.disponivel).ToList();


        }
        #endregion

        
    }
}