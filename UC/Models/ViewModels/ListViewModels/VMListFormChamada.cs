using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListFormChamada
    {
        public VMAula aula { get; set; }
        public List<VMFormChamada> chamadas { get; set; }
        public long aulaUID { get; set; }

        public VMListFormChamada()
        {

        }
        public VMListFormChamada(Aula aula)
        {
            this.aula = new VMAula(aula);
            this.aulaUID = aula.aulaUID;

            this.chamadas = new List<VMFormChamada>();

            if (aula.Chamadas != null && aula.Chamadas.Any(x => x.ativa))
            {
                foreach (var cadaChamada in aula.Chamadas.Where(x => x.ativa).ToList())
                {
                    this.chamadas.Add(new VMFormChamada(cadaChamada));
                }
            }
            else
            {
                foreach (var cadaAluno in aula.Turma.Alunoes.Where(x => x.ativo).ToList())
                {
                    this.chamadas.Add(new VMFormChamada(cadaAluno, aula));
                }
            }
            
        }
    }
}