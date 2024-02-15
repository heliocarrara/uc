using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum TipoCiclo
    {
        [Description("Diário")]
        Diario = 1,

        [Description("Semanal")]
        Semanal = 2,

        [Description("Mensal")]
        Mensal = 3,

        [Description("Anual")]
        Anual = 4
    }
}