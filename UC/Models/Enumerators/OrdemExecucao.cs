using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum OrdemExecucao
    {
        [Description("Domingo")]
        Antes_Habito_Gatilho = 1,

        [Description("Segunda-feira")]
        Durante_Habito_Gatilho = 2,

        [Description("Terça-feira")]
        Apos_Habito_Gatilho = 3
    }
}