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

        public VMListModalidade(List<ModalidadeSet> modalidades)
        {
            this.Modalidades = new List<VMModalidade>();

            foreach (var cadaModalidade in modalidades)
            {
                this.Modalidades.Add( new VMModalidade(cadaModalidade));
            }
        }
        #endregion
    }
}