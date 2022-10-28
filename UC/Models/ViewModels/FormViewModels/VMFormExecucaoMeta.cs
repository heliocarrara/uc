using System;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormExecucaoMeta
    {
        public Meta meta { get; set; }
        public long metaUID { get; set; }
        public long execucaoMetaUID { get; set; }
        public string descricao { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public string tema { get; set; }

        public VMFormExecucaoMeta()
        {
        }

        public VMFormExecucaoMeta(Meta meta)
        {
            this.meta = meta;
            this.metaUID = meta.metaUID;
            this.dataInicio = meta.dataInicio.Value;
            this.dataTermino = meta.dataObjetivo.Value;
            this.execucaoMetaUID = 0;
        }

        public VMFormExecucaoMeta(ExecucaoMeta passo)
        {
            this.meta = passo.Meta;
            this.metaUID = passo.metaUID;
            this.descricao = passo.descricao;
            this.dataInicio = passo.dataInicio;
            this.dataTermino = passo.dataTermino;
            this.tema = passo.tema;
            this.execucaoMetaUID = passo.execucaoMetaUID;
        }
    }
}