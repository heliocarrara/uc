using System;
using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListProfessorTurma
    {
        #region PROPERTIES
        public List<VMProfessorTurma> ProfessoresDaTurma { get; set; }
        public long? turmaUID { get; set; }
        public long? pessoaUID { get; set; }
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

        public VMListProfessorTurma(IUnityOfHelpers u, Pessoa pessoa)
        {
            var professor = pessoa.Professors.FirstOrDefault(x => x.ativo && x.validade > DateTime.Now);
            this.ProfessoresDaTurma = new List<VMProfessorTurma>();

            this.pessoaUID = pessoa.pessoaUID;

            if (professor != null)
            {
                if (professor != null && professor.ProfessorTurmas.Any(x => x.ativo))
                {
                    foreach (var cadaProfessorTurma in professor.ProfessorTurmas.Where(x => x.ativo).ToList())
                    {
                        this.ProfessoresDaTurma.Add(new VMProfessorTurma(u, cadaProfessorTurma));
                    }
                }
            }
        }
        #endregion
    }
}