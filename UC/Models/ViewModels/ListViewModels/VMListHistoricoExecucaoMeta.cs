using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListHistoricoExecucaoMeta
    {
        public RegistroSituacaoExecucaoMeta Registro { get; set; }
        
        public DateTime DataRegistroAnterior { get; set; }
        public DateTime DataRegistroAtual { get; set; }
        public string Situacao { get; set; }

        public VMListHistoricoExecucaoMeta(ExecucaoMeta execucao)
        {
            
        }
    }
}