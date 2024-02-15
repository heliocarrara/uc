using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum TipoGatilho
    {
        [Description("Por Ciclo")]
        Ciclo = 1,

        [Description("Por outro Hábito")]
        Habito = 2,

        [Description("Pela Mente")]
        Mente = 3
    }
}