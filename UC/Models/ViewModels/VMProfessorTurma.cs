namespace UC.Models.ViewModels
{
    public class VMProfessorTurma
    {
        public long professorTurmaUID { get; set; }
        public long professorUID { get; set; }
        public string nome { get; set; }
        public string validade { get; set; }
        public VMProfessorTurma(ProfessorTurma professor)
        {
            this.professorTurmaUID = professor.professorturmaUID;
            this.validade = professor.Professor.validade.ToShortDateString();

            this.nome = professor.Professor.Pessoa.nome;
            this.professorUID = professor.professorUID;
        }
    }
}