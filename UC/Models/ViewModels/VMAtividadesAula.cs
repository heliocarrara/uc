namespace UC.Models.ViewModels
{
    public class VMAtividadesAula
    {
        public long atividadeaulaUID { get; set; }
        public long aulaUID { get; set; }
        public bool ativa { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int duracaoMin { get; set; }
        public int ordem { get; set; }
        public bool aprovado { get; set; }

        public VMAtividadesAula()
        {
        }

        public VMAtividadesAula(AtividadeAula atividadeAulas)
        {
            this.atividadeaulaUID = atividadeAulas.atividadeaulaUID;
            this.aulaUID = atividadeAulas.aulaUID;
            this.ativa = atividadeAulas.ativa;
            this.titulo = atividadeAulas.titulo;
            this.descricao = atividadeAulas.descricao;
            this.duracaoMin = atividadeAulas.duracaoMin;
            this.ordem = atividadeAulas.ordem;
            this.aprovado = atividadeAulas.aprovado;
        }
    }
}