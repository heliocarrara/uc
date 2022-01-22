using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormDiaDaSemanaTurma
    {
        public long diasemanaturmaUID { get; set; }
        public long turmaUID { get; set; }
        public string nomeTurma { get; set; }
        public SelectList DiasDisponiveis { get; set; }
        public int? diaSemanal { get; set; }

        public VMFormDiaDaSemanaTurma()
        {
        }
        public VMFormDiaDaSemanaTurma(IUnityOfHelpers u, Turma turma)
        {
            this.nomeTurma = u.Turmas.GetNomeTurma(turma);
            this.DiasDisponiveis = u.SelectLists.DiasDaSemana(null);
            this.turmaUID = turma.turmaUID;
        }

        /*public VMFormDiaDaSemanaTurma(IUnityOfHelpers u, DiaSemanaTurma dia)
        {
            this.DiasDisponiveis = u.SelectLists.DiasDaSemana(dia.diaSemanal);
            this.turmaUID = dia.turmaUID;
            this.HorarioInicio = dia.Turma.HorarioInicio.ToShortTimeString();
            this.diaSemanal = dia.diaSemanal;
            this.diasemanaturmaUID = dia.diasemanaturmaUID;
        }*/
    }
}