using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListExecucaoMeta
    {
        public List<VMExecucaoMeta> AtividadesDoDia { get; set; }
        public DateTime Dia { get; set; }

        public VMListExecucaoMeta()
        {
        }

        public VMListExecucaoMeta(List<ExecucaoMeta> atividadesDoDia, DateTime dia)
        {
            AtividadesDoDia = new List<VMExecucaoMeta>();
            Dia = dia;

            foreach(var cadaAtividade in atividadesDoDia)
            {
                AtividadesDoDia.Add(new VMExecucaoMeta(cadaAtividade));
            }
        }
    }
}