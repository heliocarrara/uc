using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAluno
    {
        #region PROPERTIES
        public List<VMAluno> Alunos { get; set; }
        public long? turmaUID { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListAluno()
        {

        }

        public VMListAluno(Turma turma)
        {
            this.turmaUID = turma.turmaUID;

            this.Alunos = new List<VMAluno>();

            if (turma.Alunoes != null)
            {
                foreach (var cadaAluno in turma.Alunoes.Where(x => x.ativo).ToList())
                {
                    this.Alunos.Add(new VMAluno(cadaAluno));
                }
            }
        }
        public VMListAluno(List<Aluno> alunos)
        {
            this.Alunos = new List<VMAluno>();

            if (alunos != null)
            {
                foreach (var cadaAluno in alunos)
                {
                    this.Alunos.Add(new VMAluno(cadaAluno));
                }
            }
        }
        #endregion
    }
}