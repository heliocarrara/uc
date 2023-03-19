using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListRelatorioExecucaoMeta
    {
        public ExecucaoMeta execucaoMeta { get; set; }
        public int MinExecutando { get; set; }
        public int MinPausado { get; set; }
        public int MinImterrompido { get; set; }
        public int PeriodoAntecedencia { get; set; }
        public int PeriodoExtendido { get; set; }

        public VMListRelatorioExecucaoMeta(ExecucaoMeta execucaoMeta)
        {
            this.execucaoMeta = execucaoMeta;

            var registros = execucaoMeta.RegistroSituacaoExecucaoMetas.Where(x => x.ativo).ToList();

            for (var i = 0; i < registros.Count; i++)
            {
                switch ((SituacaoPasso)registros[i].situacaoPasso)
                {
                    case SituacaoPasso.Em_Andamento:
                        if ((i + 1) < registros.Count)
                        {
                            this.MinExecutando += (int)registros[i + 1].dataCriacao.Subtract(registros[i].dataCriacao).TotalMinutes;
                        }
                        else
                        {
                            this.MinExecutando += (int)DateTime.Now.Subtract(registros[i].dataCriacao).TotalMinutes;
                        }
                        break;
                    case SituacaoPasso.Pausado:
                        if ((i + 1) < registros.Count)
                        {
                            this.MinPausado += (int)registros[i + 1].dataCriacao.Subtract(registros[i].dataCriacao).TotalMinutes;
                        }
                        break;
                    case SituacaoPasso.Concluido:
                        if(registros[i].dataCriacao > execucaoMeta.dataTermino)
                        {
                            this.PeriodoExtendido = (int)registros[i].dataCriacao.Subtract(execucaoMeta.dataTermino).TotalMinutes;
                        }
                        break;
                    case SituacaoPasso.Interrompido:
                        if ((i + 1) < registros.Count)
                        {
                            this.MinImterrompido += (int)registros[i + 1].dataCriacao.Subtract(registros[i].dataCriacao).TotalMinutes;
                        }
                        break;
                }
            }

            var momentoInicial = registros.FirstOrDefault(x => x.ativo && x.situacaoPasso == (int)SituacaoPasso.Em_Andamento);
        
            if (momentoInicial != null)
            {
                this.PeriodoAntecedencia = execucaoMeta.dataInicio.Subtract(momentoInicial.dataCriacao).Minutes;
            }
        }
    }
}