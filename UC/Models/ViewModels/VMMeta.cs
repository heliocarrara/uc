
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<VMExecucaoMeta> Passos { get; set; }
        public VMMeta()
        {
        }

        public VMMeta (Meta meta)
        {
            this.metaUID = meta.metaUID;
            this.nome = meta.nome;
            this.dataInicio = meta.dataInicio.Value;
            this.dataTermino = meta.dataObjetivo.Value;
            this.prioridade = meta.ordemPrioridade;
            this.motivo = meta.motivo;

            this.Passos = new List<VMExecucaoMeta>();

            foreach(var cadaPasso in meta.ExecucaoMetas.Where(x => x.ativo).ToList())
            {
                this.Passos.Add(new VMExecucaoMeta(cadaPasso));
            }

            this.Passos = this.Passos.OrderBy(x => x.ordem).ToList();
        }
    }
}