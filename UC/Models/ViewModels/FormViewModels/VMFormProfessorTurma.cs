using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormProfessorTurma
    {
        public long? professorUID { get; set; }
        public long? turmaUID { get; set; }
        public string nomeTurma { get; set; }

        public SelectList ProfessoresDisponiveis { get; set; }
        public SelectList TurmasDisponiveis { get; set; }

        public VMFormProfessorTurma()
        {
        }
        public VMFormProfessorTurma(IUnityOfHelpers u)
        {
            this.TurmasDisponiveis = u.SelectLists.TurmasDisponiveis(null);
            this.ProfessoresDisponiveis = u.SelectLists.ProfessoresDisponiveis(null);
        }

        public VMFormProfessorTurma(IUnityOfHelpers u, Turma turma)
        {
            this.TurmasDisponiveis = u.SelectLists.TurmasDisponiveis(turma.turmaUID);
            this.ProfessoresDisponiveis = u.SelectLists.ProfessoresDisponiveis(null);

            this.turmaUID = turma.turmaUID;
            this.nomeTurma = u.Turmas.GetNomeTurma(turma);
        }
    }
}