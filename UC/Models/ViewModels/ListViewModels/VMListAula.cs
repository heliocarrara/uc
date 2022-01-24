using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAula
    {
        #region PROPERTIES
        public List<VMAula> Aulas { get; set; }
        public long? turmaUID { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListAula()
        {

        }

        public VMListAula(Turma turma)
        {
            this.turmaUID = turma.turmaUID;

            this.Aulas = new List<VMAula>();

            if (turma.Aulas != null)
            {
                foreach (var cadaAula in turma.Aulas.Where(x => x.ativa).ToList())
                {
                    this.Aulas.Add(new VMAula(cadaAula));
                }
            }
        }
        public VMListAula(List<Aula> aulas)
        {
            this.Aulas = new List<VMAula>();

            if (aulas != null)
            {
                foreach (var cadaAula in aulas)
                {
                    this.Aulas.Add(new VMAula(cadaAula));
                }
            }
        }
        #endregion
    }
}