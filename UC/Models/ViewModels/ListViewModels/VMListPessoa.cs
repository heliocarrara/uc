using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListPessoa
    {
        public List<VMPessoa> Pessoas { get; set; }

        public VMListPessoa(List<Pessoa> pessoas)
        {
            this.Pessoas = new List<VMPessoa>();
        
            foreach(var cadaPessoa in pessoas)
            {
                this.Pessoas.Add(new VMPessoa(cadaPessoa));
            }
        }
    }
}