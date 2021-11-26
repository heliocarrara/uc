using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum TipoModalidade
    {
        [Description("Hidroginástica")]
        Hidroginastica = 1,

        [Description("Treinamento Funcional")]
        Treinamento_Funcional = 2,

        [Description("Natação")]
        Natacao = 3,

        [Description("Muay Thay Fitness")]
        Muay_Thay = 4,

        [Description("Ritmos")]
        Ritmos = 5,

        [Description("Balé Clássico")]
        Bale = 6,

        [Description("Submission No Gi")]
        Submission = 7,

        [Description("Futebol de Campo")]
        Futebol_de_Campo = 8
        
    }
}