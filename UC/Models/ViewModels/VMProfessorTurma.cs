namespace UC.Models.ViewModels
{
    public class VMProfessorTurma
    {
        public long professorTurmaUID { get; set; }
        public string nome { get; set; }
        public string vinculo { get; set; }
        public string validade { get; set; }
        public VMProfessorTurma(ProfessorTurma professor)
        {
            this.professorTurmaUID = professor.professorturmaUID;
            this.validade = professor.Professor.validade.ToShortDateString();

            if (professor.Professor.bolsistaUID.HasValue)
            {
                this.nome = professor.Professor.Bolsista.Pessoa.nome;
                this.vinculo = "Aluno Bolsista";
            }
            else if (professor.Professor.autonomoUID.HasValue)
            {
                this.nome = professor.Professor.Autonomo.Pessoa.nome;
                this.vinculo = "Autônomo";
            } 
            else if (professor.Professor.coordenadorUID.HasValue)
            {
                this.nome = professor.Professor.Coordenador.Pessoa.nome;
                this.vinculo = "Coordenador";
            }
            else
            {
                this.nome = "Professor inválido";
                this.vinculo = "Sem vínculo";
            }
        }
    }
}