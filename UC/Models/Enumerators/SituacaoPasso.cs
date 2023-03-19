using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UC.Models.Enumerators
{
    public enum SituacaoPasso
    {
        [Description("Aguardando início")]
        Inicio = 0,

        [Description("Em andamento")]
        Em_Andamento = 2,

        [Description("Pausado")]
        Pausado = 3,

        [Description("Interrompido")]
        Interrompido = 4,

        [Description("Concluído")]
        Concluido = 5
    }
}