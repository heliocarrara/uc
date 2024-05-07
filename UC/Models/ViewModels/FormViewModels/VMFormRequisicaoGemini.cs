namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormRequisicaoGemini
    {
        public string Prompt { get; set; }
        public string Resultado { get; set; }

        public VMFormRequisicaoGemini()
        {
        }

        public VMFormRequisicaoGemini(string prompt)
        {
            Prompt = prompt;
        }

        public VMFormRequisicaoGemini(string prompt, string resultado) : this(prompt)
        {
            Resultado = resultado;
        }
    }
}