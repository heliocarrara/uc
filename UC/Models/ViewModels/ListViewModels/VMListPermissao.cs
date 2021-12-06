using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListPermissao
    {
        public List<VMPermissao> Permissoes { get; set; }
        public VMListPermissao()
        {
        }

        public VMListPermissao(List<VMPermissao> permissoes)
        {
            this.Permissoes = permissoes;
        }
    }
}