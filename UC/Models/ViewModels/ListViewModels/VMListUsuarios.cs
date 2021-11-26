using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListUsuarios
    {
        public List<Pessoa> pessoas { get; set; }
        public List<Login> logins { get; set; }

        public VMListUsuarios(List<Pessoa> pessoas, List<Login> logins)
        {
            this.pessoas = pessoas;
            this.logins = logins;
        }
    }
}