using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Models.ViewModels
{
    public class VMCronograma
    {
        public long? execucaoMetaUID { get; set; }
        public long? horarioHabitoUID { get; set; }
        public long? metaUID { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int duracao { get; set; }
        public int situacao { get; set; }
        public string Nome { get; set; }
        public string NomeMeta { get; set; }
        public ExecucaoMeta ExecucaoMeta { get; set; }
        public HorarioHabito HorarioHabito { get; set; }
        public VMCronograma()
        {
        }

        public VMCronograma(ExecucaoMeta passo)
        {
            this.execucaoMetaUID = passo.execucaoMetaUID;
            this.metaUID = passo.metaUID;
            this.dataInicio = passo.dataInicio;
            this.dataTermino = passo.dataTermino;
            this.duracao = (int)passo.dataTermino.Subtract(passo.dataInicio).TotalMinutes;
            this.situacao = passo.situacao;
            this.ExecucaoMeta = passo;
            this.Nome = passo.descricao;
            this.NomeMeta = passo.Meta.nome;
        }
        public VMCronograma(HorarioHabito horarioHabito, DateTime dia)
        {
            this.horarioHabitoUID = horarioHabito.horarioHabitoUID;
            this.dataInicio = dia.Add(horarioHabito.HorarioInicio);
            this.dataTermino = dia.Add(horarioHabito.HorarioTermino);
            this.duracao = (int)dataTermino.Subtract(dataInicio).TotalMinutes;
            this.situacao = (int)SituacaoPasso.Inicio;
            this.HorarioHabito = horarioHabito;

            if (horarioHabito.cicloHabitoUID.HasValue)
            {
                this.Nome = horarioHabito.CicloHabito.Habito.Descricao;
                this.NomeMeta = horarioHabito.CicloHabito.Habito.Meta.nome;
                this.metaUID = horarioHabito.CicloHabito.Habito.metaUID;
            }
            else
            {
                this.Nome = horarioHabito.DiaSemanaHabito.Habito.Descricao;
                this.NomeMeta = horarioHabito.DiaSemanaHabito.Habito.Meta.nome;
                this.metaUID = horarioHabito.CicloHabito.Habito.metaUID;
            }
        }
    }
}