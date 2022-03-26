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

        public VMListPermissao(Pessoa pessoa) : this(pessoa.Permissaos.ToList())
        {
        }

        public VMListPermissao(List<Permissao> permissoes)
        {
            this.Permissoes = new List<VMPermissao>();

            foreach (var cadaPermissao in permissoes)
            {
                this.Permissoes.Add(new VMPermissao(cadaPermissao));
            }
        }

        public VMListPermissao(List<VMPermissao> permissoes)
        {
            this.Permissoes = permissoes;
        }
    }
}