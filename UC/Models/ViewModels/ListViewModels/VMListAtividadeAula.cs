using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAtividadeAula
    {
        #region PROPERTIES
        public List<VMAtividadesAula> atividadeAulas { get; set; }
        public long? aulaUID { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListAtividadeAula()
        {

        }

        public VMListAtividadeAula(Aula aula)
        {
            this.aulaUID = aula.aulaUID;

            this.atividadeAulas = new List<VMAtividadesAula>();

            if (aula.AtividadeAulas != null)
            {
                foreach (var cadaAula in aula.AtividadeAulas.Where(x => x.ativa).ToList())
                {
                    this.atividadeAulas.Add(new VMAtividadesAula(cadaAula));
                }
            }
        }
        public VMListAtividadeAula(List<AtividadeAula> atividades)
        {
            this.atividadeAulas = new List<VMAtividadesAula>();

            if (atividades != null)
            {
                foreach (var cadaAtividade in atividades)
                {
                    this.atividadeAulas.Add(new VMAtividadesAula(cadaAtividade));
                }
            }
        }
        #endregion
    }
}