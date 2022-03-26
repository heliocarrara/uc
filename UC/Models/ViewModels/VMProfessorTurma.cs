namespace UC.Models.ViewModels
{
    public class VMProfessorTurma
    {
        public long professorTurmaUID { get; set; }
        public long professorUID { get; set; }
        public long turmaUID { get; set; }
        public string nome { get; set; }
        public string nomeTurma { get; set; }
        public string validade { get; set; }


        public VMProfessorTurma()
        {
        }

        public VMProfessorTurma(ProfessorTurma professor)
        {
            this.nome = professor.Professor.Pessoa.nome;
            this.professorUID = professor.professorUID;
            this.professorTurmaUID = professor.professorturmaUID;
            this.validade = professor.Professor.validade.ToShortDateString();
            this.turmaUID = professor.turmaUID;
        }

        public VMProfessorTurma(IUnityOfHelpers u, ProfessorTurma professor)
        {
            this.nomeTurma = u.Turmas.GetNomeTurma(professor.Turma);
            this.professorTurmaUID = professor.professorturmaUID;
            this.validade = professor.Professor.validade.ToShortDateString();
            this.turmaUID = professor.turmaUID;
        }
    }
}