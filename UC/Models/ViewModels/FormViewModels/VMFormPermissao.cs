using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormPermissao
    {
        public long permissaoUID { get; set; }
        public long pessoaUID { get; set; }
        public string cpf { get; set; }
        public int tipoLogin { get; set; }
        public DateTime validade { get; set; }
        public Pessoa pessoa { get; set; }
        public SelectList tiposDeLogin { get; set; }

        public VMFormPermissao()
        {
        }

        public VMFormPermissao(IUnityOfHelpers u)
        {
            this.tiposDeLogin = u.SelectLists.TiposDeLogin(null);
        }

        public VMFormPermissao(Permissao permissao, IUnityOfHelpers u)
        {
            this.permissaoUID = permissao.permissaoUID;
            this.pessoaUID = permissao.pessoaUID;
            this.tipoLogin = permissao.tipoLogin;
            this.validade = permissao.validade;
            this.tiposDeLogin = u.SelectLists.TiposDeLogin(permissao.tipoLogin);

            this.pessoa = u.idbucContext.Pessoas.Find(permissao.pessoaUID);
        }
    }
}