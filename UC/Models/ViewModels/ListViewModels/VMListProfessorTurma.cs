using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListProfessorTurma
    {
        #region PROPERTIES
        public List<VMProfessorTurma> ProfessoresDaTurma { get; set; }
        public long? turmaUID { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListProfessorTurma()
        {

        }

        public VMListProfessorTurma(Turma turma)
        {
            this.turmaUID = turma.turmaUID;

            this.ProfessoresDaTurma = new List<VMProfessorTurma>();

            if (turma.ProfessorTurmas != null)
            {
                foreach (var cadaProfessorTurma in turma.ProfessorTurmas.Where(x => x.ativo).ToList())
                {
                    this.ProfessoresDaTurma.Add(new VMProfessorTurma(cadaProfessorTurma));
                }
            }
        }
        public VMListProfessorTurma(List<ProfessorTurma> professoresDaTurma)
        {
            this.ProfessoresDaTurma = new List<VMProfessorTurma>();

            if (professoresDaTurma != null)
            {
                foreach (var cadaProfessorTurma in professoresDaTurma)
                {
                    this.ProfessoresDaTurma.Add(new VMProfessorTurma(cadaProfessorTurma));
                }
            }
        }
        #endregion
    }
}