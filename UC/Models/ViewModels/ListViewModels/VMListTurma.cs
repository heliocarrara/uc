using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListTurma
    {
        #region PROPERTIES
        public List<VMTurma> Turmas { get; set; }
        public int VagasTotais { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListTurma()
        {

        }

        public VMListTurma(IUnityOfHelpers u, List<Turma> turmas)
        {
            this.Turmas = new List<VMTurma>();

            foreach (var cadaTurma in turmas)
            {
                this.Turmas.Add( new VMTurma(u, cadaTurma));
            }

            this.VagasTotais = this.Turmas.Sum(x => x.Vagas);
        }
        public VMListTurma(IUnityOfHelpers u, Modalidade modalidade)
        {
            this.Turmas = new List<VMTurma>();

            foreach (var cadaTurma in modalidade.Turmas.Where(x => x.ativa && x.disponivel).ToList())
            {
                this.Turmas.Add(new VMTurma(u, cadaTurma));
            }

            this.VagasTotais = this.Turmas.Sum(x => x.Vagas);
        }

        public VMListTurma(IUnityOfHelpers u, List<ProfessorTurma> turmas)
        {
            this.Turmas = new List<VMTurma>();

            foreach (var cadaTurma in turmas)
            {
                this.Turmas.Add(new VMTurma(u, cadaTurma.Turma));
            }

            this.VagasTotais = this.Turmas.Sum(x => x.Vagas);
        }
        #endregion
    }
}