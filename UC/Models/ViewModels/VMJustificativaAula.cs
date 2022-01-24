namespace UC.Models.ViewModels
{
    public class VMJustificativaAula
    {
        public long justificativaaulaUID { get; set; }
        public long chamadaUID { get; set; }
        public bool ativa { get; set; }
        public bool foiAprovada { get; set; }
        public string justificativa { get; set; }

        public VMJustificativaAula()
        {
        }

        public VMJustificativaAula (JustificativaAula justificativa)
        {
            this.justificativaaulaUID = justificativa.justificativaaulaUID;
            this.chamadaUID = justificativa.chamadaUID;
            this.ativa = justificativa.ativa;
            this.foiAprovada = justificativa.aprovadaCoordenador;
            this.justificativa = justificativa.justificativa;
        }
    }
}