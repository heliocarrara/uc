using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMExecucaoMeta
    {
        public long execucaoMetaUID { get; set; }
        public int ordem { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public string descricao { get; set; }
        public int duracao { get; set; }
        public string observacao { get; set; }
        public string tema { get; set; }
        public VMExecucaoMeta()
        {
        }

        public VMExecucaoMeta(ExecucaoMeta passo)
        {
            this.execucaoMetaUID = passo.execucaoMetaUID;
            this.ordem = passo.ordemPasso;
            this.dataInicio = passo.dataInicio;
            this.dataTermino = passo.dataTermino;
            this.descricao = passo.descricao;
            this.duracao = (int)passo.dataTermino.Subtract(passo.dataInicio).TotalMinutes;
            this.observacao = passo.Meta.motivo;
            this.tema = passo.tema;
        }
    }
}