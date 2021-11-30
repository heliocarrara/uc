using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListModalidade
    {
        #region PROPERTIES
        public List<VMModalidade> Modalidades { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListModalidade()
        {

        }

        public VMListModalidade(List<VMModalidade> modalidades)
        {
            this.Modalidades = modalidades;
        }
        #endregion
    }
}