using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Models.ViewModels
{
    public class VMExecucaoMeta
    {
        public long execucaoMetaUID { get; set; }
        public long metaUID { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int duracao { get; set; }
        public string situacao { get; set; }
        public ExecucaoMeta execucaoMeta { get; set; }
        public List<AnotacaoExecucaoMeta> Anotacoes { get; set; }
        public List<RegistroSituacaoExecucaoMeta> Historico { get; set; }
        public VMListRelatorioExecucaoMeta RelatorioExecucao { get; set; }
        public VMExecucaoMeta()
        {
        }

        public VMExecucaoMeta(ExecucaoMeta passo)
        {
            this.execucaoMetaUID = passo.execucaoMetaUID;
            this.metaUID = passo.metaUID;
            this.dataInicio = passo.dataInicio;
            this.dataTermino = passo.dataTermino;
            this.duracao = (int)passo.dataTermino.Subtract(passo.dataInicio).TotalMinutes;
            this.situacao = ((SituacaoPasso)passo.situacao).ToFriendlyString();

            this.execucaoMeta = passo;

            this.Anotacoes = this.execucaoMeta.AnotacaoExecucaoMetas.Where(x => x.ativo).ToList();
            this.Historico = this.execucaoMeta.RegistroSituacaoExecucaoMetas.Where(x => x.ativo).ToList();

            this.RelatorioExecucao = new VMListRelatorioExecucaoMeta(this.execucaoMeta);

        }
    }
}