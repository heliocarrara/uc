using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListAluno
    {
        #region PROPERTIES
        public List<VMAluno> Alunos { get; set; }
        public long? turmaUID { get; set; }
        public long? pessoaUID { get; set; }
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

        public VMListAluno(IUnityOfHelpers u, Pessoa pessoa)
        {
            this.pessoaUID = pessoa.pessoaUID;

            this.Alunos = new List<VMAluno>();

            if (pessoa.Alunoes != null)
            {
                foreach (var cadaAluno in pessoa.Alunoes.Where(x => x.ativo).ToList())
                {
                    this.Alunos.Add(new VMAluno(u, cadaAluno));
                }
            }
        }
        #endregion
    }
}