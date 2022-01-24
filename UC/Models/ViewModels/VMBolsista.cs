using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMBolsista
    {
        public long bolsistaUID { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public VMBolsista()
        {
        }

        public VMBolsista(Bolsista bolsista)
        {
            this.bolsistaUID = bolsista.bolsistaUID;
            this.cpf = bolsista.Pessoa.cpf;
            this.nome = bolsista.Pessoa.nome;
        }
    }
}