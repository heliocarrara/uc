using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels
{
    public class VMPermissao
    {
        public long permissaoUID { get; set; }
        public long pessoaUID { get; set; }
        public int tipoLogin { get; set; }
        public string tipoDeLogin { get; set; }
        public DateTime validade { get; set; }
        public DateTime dataCriacao { get; set; }
        public Pessoa pessoa { get; set; }

        public VMPermissao()
        {
        }

        public VMPermissao(Permissao permissao, IUnityOfHelpers u)
        {
            this.permissaoUID = permissao.permissaoUID;
            this.pessoaUID = permissao.pessoaUID;
            this.tipoLogin = permissao.tipoLogin;
            this.validade = permissao.validade;
            this.dataCriacao = permissao.dataCriacao;
            this.pessoa = permissao.Pessoa;

            this.tipoDeLogin = ((TipoLogin)permissao.tipoLogin).ToFriendlyString();
        }
    }
}