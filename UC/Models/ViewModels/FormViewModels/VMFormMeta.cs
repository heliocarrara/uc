using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormMeta
    {
        public long metaUID { get; set; }
        public string nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public string motivo { get; set; }
        public int ordem { get; set; }
        public string tema { get; set; }
        public SelectList tiposDisponiveis { get; set; }
        public SelectList subTipoDisponiveis { get; set; }
        public int? tipoMeta { get; set; }
        public int? subTipoMetaUID { get; set; }

        public VMFormMeta()
        {

        }

        public VMFormMeta(IUnityOfHelpers u)
        {
            this.metaUID = 0;
            this.tiposDisponiveis = u.SelectLists.TiposDeMeta(null);
            this.subTipoDisponiveis = u.SelectLists.SubTiposMeta(null);
            this.dataInicio = DateTime.Now;
            this.dataTermino = this.dataInicio.AddMonths(1);
        }

        public VMFormMeta (IUnityOfHelpers u, Meta meta)
        {
            this.metaUID = meta.metaUID;
            this.nome = meta.nome;
            this.dataInicio = meta.dataInicio;
            this.dataTermino = meta.dataObjetivo;
            this.motivo = meta.motivo;
            this.ordem = meta.ordemPrioridade;
            this.tema = meta.tema;
            this.tipoMeta = meta.tipo;
            this.subTipoMetaUID = meta.subTipoMetaUID;
            this.tiposDisponiveis = u.SelectLists.TiposDeMeta(meta.tipo);
            this.subTipoDisponiveis = u.SelectLists.SubTiposMeta(meta.subTipoMetaUID);
        }
    }
}