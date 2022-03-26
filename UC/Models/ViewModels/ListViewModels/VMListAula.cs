using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAula
    {
        #region PROPERTIES
        public List<VMAula> Aulas { get; set; }
        public long? turmaUID { get; set; }
        public long? alunoUID { get; set; }
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

        public VMListAula(Aluno aluno)
        {
            this.alunoUID = aluno.alunoUID;

            this.Aulas = new List<VMAula>();

            if (aluno.Turma.Aulas != null)
            {
                foreach (var cadaChamada in aluno.Turma.Aulas.Where(x => x.ativa).ToList())
                {
                    this.Aulas.Add(new VMAula(cadaChamada, aluno.alunoUID));
                }
            }
        }
        #endregion
    }
}