using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UC.Utility;

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

        public SelectList ListaMeta { get; set; }

        public VMFormExecucaoMeta()
        {
        }

        public VMFormExecucaoMeta(IUnityOfHelpers u)
        {
            this.ListaMeta = u.SelectLists.MetasPorUsuario(null);

            this.dataInicio = DateTime.Now;
            this.dataTermino = DateTime.Now.AddHours(1);
        }

        public VMFormExecucaoMeta(IUnityOfHelpers u, Meta meta)
        {
            this.ListaMeta = u.SelectLists.MetasPorUsuario(meta.metaUID);
            this.meta = meta;
            this.metaUID = meta.metaUID;
            this.execucaoMetaUID = 0;
            this.dataInicio = DateTime.Now;
            this.dataTermino = DateTime.Now.AddHours(1);
        }
        public VMFormExecucaoMeta(IUnityOfHelpers u, ExecucaoMeta passo)
        {
            this.ListaMeta = u.SelectLists.MetasPorUsuario(passo.metaUID);
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