using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum TipoLogin
    {
        [Description("Aluno")]
        Aluno = 1,

        [Description("Administrador")]
        Administrador = 2,

        [Description("Bolsista")]
        Bolsista = 3,

        [Description("Coordenador")]
        Coordenador = 4,

        [Description("Uniselva")]
        Uniselva = 5,

        [Description("Secretario")]
        Secretario = 6
    }
}