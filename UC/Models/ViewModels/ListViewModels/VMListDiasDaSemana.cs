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

        public VMListDiasDaSemana(IUnityOfHelpers u, Turma turma)
        {
            this.turmaUID = turma.turmaUID;

            this.DiasSemanais = new List<VMDiaSemanal>();

            foreach (var cadaDia in turma.DiaSemanaTurmas.Where(x => x.ativo).ToList())
            {
                this.DiasSemanais.Add(new VMDiaSemanal(cadaDia));
            }

            this.todosOsDias = u.Turmas.GetDiasDaSemana(turma);
        }
    }
}