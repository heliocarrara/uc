using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UC.Utility;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAnotacao
    {
        public List<AnotacaoExecucaoMeta> ListaAnotacoes { get; set; }

        public DateTime? Dia { get; set; }

        public long? metaUID { get; set; }

        public long? execucaoMetaUID { get; set; }

        public SelectList ListaExecucaoMeta { get; set; }

        public VMListAnotacao()
        {
        }
        public VMListAnotacao(IUnityOfHelpers u, DateTime? dia)
        {
            var inicioDia = dia.HasValue ? dia.Value.Date : DateTime.Today;
            var fimDia = inicioDia.AddHours(23).AddMinutes(59);

            var listaExecucao = u.idbucContext.ExecucaoMetas.Where(x =>
                    x.ativo
                    && x.Meta.usuarioUID == SimpleSessionPersister.usuarioUID
                    && x.dataInicio < fimDia
                    && x.dataTermino >= inicioDia).ToList();

            this.ListaExecucaoMeta = u.SelectLists.ExecucaoDia(listaExecucao, null);
        }

        public VMListAnotacao(Meta meta)
        {
            this.metaUID = meta.metaUID;
            this.ListaAnotacoes = new List<AnotacaoExecucaoMeta>();

            foreach(var cadaPasso in meta.ExecucaoMetas.Where(x => x.ativo).ToList())
            {
                this.ListaAnotacoes.AddRange(cadaPasso.AnotacaoExecucaoMetas.Where(y => y.ativo).ToList());
            }
        }
        public VMListAnotacao(ExecucaoMeta execucaoMeta)
        {
            this.execucaoMetaUID = execucaoMeta.execucaoMetaUID;
            this.ListaAnotacoes = new List<AnotacaoExecucaoMeta>();

            this.ListaAnotacoes.AddRange(execucaoMeta.AnotacaoExecucaoMetas.Where(y => y.ativo).ToList());
        }

        public VMListAnotacao(IUnityOfHelpers u, List<AnotacaoExecucaoMeta> anotacoes, DateTime? dia) : this(u, dia)
        {
            ListaAnotacoes = anotacoes;
            Dia = dia;
        }
    }
}