using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UC.Models.ViewModels
{
    public class VMHabito
    {
        public Habito Habito { get; set; }

        public VMHabito(IUnityOfHelpers u, Habito habito)
        {
            Habito = habito;
        }
    }
}