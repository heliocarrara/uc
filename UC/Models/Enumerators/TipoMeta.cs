using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UC.Models.Enumerators
{
    public enum TipoMeta
    {
        [Description("Educação")]
        Educacao = 1,

        [Description("Finanças")]
        Financa = 2,

        [Description("Saúde")]
        Saude = 3,

        [Description("Trabalho")]
        Trabalho = 4,

        [Description("Amizade")]
        Amizade = 5,

        [Description("Alimentação")]
        Alimentacao = 6
    }
}