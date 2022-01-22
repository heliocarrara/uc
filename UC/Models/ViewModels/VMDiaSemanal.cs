using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;

namespace UC.Models.ViewModels
{
    public class VMDiaSemanal
    {
        public long diasemanaturmaUID { get; set; }
        public string diaString { get; set; }
        public int diaSemanal { get; set; }
        public long turmaUID { get; set; }

        public VMDiaSemanal()
        {
        }

        public VMDiaSemanal(DiaSemanaTurma dia)
        {
            this.diasemanaturmaUID = dia.diasemanaturmaUID;
            this.diaSemanal = dia.diaSemanal;
            this.diaString = ((DiaSemanal)dia.diaSemanal).ToFriendlyString();
            this.turmaUID = dia.turmaUID;
        }
    }
}