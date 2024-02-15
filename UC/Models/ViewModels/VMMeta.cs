
using System;
using System.Collections.Generic;
using System.Linq;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels
{
    public class VMMeta
    {
        public long metaUID { get; set; }
        public string nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int prioridade { get; set; }
        public string motivo { get; set; }
        public string tema { get; set; }
        public string tipo { get; set; }
        public string subTipo { get; set; }
        public List<VMExecucaoMeta> Passos { get; set; }
        public List<Habito> Habitos { get; set; }
        public VMMeta()
        {
        }

        public VMMeta (IUnityOfHelpers u, Meta meta)
        {
            this.metaUID = meta.metaUID;
            this.nome = meta.nome;
            this.dataInicio = meta.dataInicio;
            this.dataTermino = meta.dataObjetivo;
            this.prioridade = meta.ordemPrioridade;
            this.motivo = meta.motivo;

            this.Passos = new List<VMExecucaoMeta>();

            foreach(var cadaPasso in meta.ExecucaoMetas.Where(x => x.ativo).ToList())
            {
                this.Passos.Add(new VMExecucaoMeta(cadaPasso));
            }

            this.Passos = this.Passos.OrderByDescending(x => x.execucaoMeta.dataInicio).ToList();
            this.Habitos = new List<Habito>();

            foreach(var cadaHabito in meta.Habitos.Where(x => x.ativo).ToList())
            {
                this.Habitos.Add(cadaHabito);
            }

            this.Habitos = this.Habitos.OrderBy(x => !x.finalizado).ThenBy(x => x.DataCriacao).ToList();

            this.tema = !string.IsNullOrWhiteSpace(meta.tema) ? meta.tema : "#000000";
            this.tipo = ((TipoMeta)meta.tipo).ToFriendlyString();

            this.subTipo = meta.subTipoMetaUID.HasValue ? u.idbucContext.SubTipoMetas.Find(meta.subTipoMetaUID.Value).nome : "Não definido";
        }
    }
}