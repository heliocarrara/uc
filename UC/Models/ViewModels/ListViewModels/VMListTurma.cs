using System.Collections.Generic;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListTurma
    {
        #region PROPERTIES
        public List<VMTurma> Turmas { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListTurma()
        {

        }

        public VMListTurma(List<VMTurma> turmas)
        {
            this.Turmas = turmas;
        }

        public VMListTurma(List<TurmaSet> turmas)
        {
            this.Turmas = new List<VMTurma>();

            foreach (var cadaTurma in turmas)
            {
                this.Turmas.Add( new VMTurma(cadaTurma));
            }
        }
        #endregion
    }
}