using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListDiasDaSemana
    {
        public List<VMDiaSemanal> DiasSemanais { get; set; }
        public string todosOsDias { get; set; }
        public long turmaUID { get; set; }
        public VMListDiasDaSemana()
        {
            this.DiasSemanais = new List<VMDiaSemanal>();
        }

        public VMListDiasDaSemana(Turma turma)
        {
            this.turmaUID = turma.turmaUID;

            this.DiasSemanais = new List<VMDiaSemanal>();
            var diasSemanais = turma.DiaSemanaTurmas.Where(x => x.ativo).ToList();

            if (diasSemanais.Any())
            {
                foreach (var cadaDia in diasSemanais.OrderBy(x => x.diaSemanal))
                {
                    var VM = new VMDiaSemanal(cadaDia);
                    this.DiasSemanais.Add(VM);
                    this.todosOsDias += VM.diaString + " || ";
                }
            }
            else
            {
                this.todosOsDias = "Nenhum dia cadastrado";
            }
        }
    }
}