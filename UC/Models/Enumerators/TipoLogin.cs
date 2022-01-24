using System.ComponentModel;

namespace UC.Models.Enumerators
{
    public enum TipoLogin
    {
        [Description("Aluno")]
        Aluno = 1,

        [Description("Secretario")]
        Administrador = 2,

        [Description("Professor")]
        Bolsista = 3,

        [Description("Coordenador")]
        Coordenador = 4,

        [Description("Uniselva")]
        Uniselva = 5,

        [Description("Visitante")]
        Visitante = 6
    }
}