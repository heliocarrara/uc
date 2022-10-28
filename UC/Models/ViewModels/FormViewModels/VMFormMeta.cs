using System;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormMeta
    {
        public long metaUID { get; set; }
        public string nome { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public string motivo { get; set; }
        public int ordem { get; set; }

        public VMFormMeta()
        {

        }
    }
}