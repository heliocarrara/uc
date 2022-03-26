using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Models.ViewModels
{
    public class VMPainelProfessor
    {
        public VMListTurma ListaTurmas { get; set; }
        public long professorUID { get; set; }
        public VMPainelProfessor()
        {
        }

        public VMPainelProfessor(IUnityOfHelpers u, Professor professor)
        {
            this.ListaTurmas = new VMListTurma();

            if(professor.ProfessorTurmas != null)
            {
                var turmasProfessor = professor.ProfessorTurmas.Where(x => x.ativo).ToList();

                if (turmasProfessor != null && turmasProfessor.Any())
                {
                    this.ListaTurmas = new VMListTurma(u, turmasProfessor);
                }
            }
        }
    }
}