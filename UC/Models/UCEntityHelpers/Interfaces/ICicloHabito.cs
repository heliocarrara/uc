using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface ICicloHabitoHelper
    {
        CicloHabito AtualizarCicloHabito(VMFormCicloHabito form, out UserMessage message);

        DiaSemanaHabito ObterDiaSemanal(int diaSemanal, Habito habito);

        CicloHabito AdicionarCiclo(int tipoCiclo, Habito habito);

        HorarioHabito AdicionarHorario(CicloHabito cicloHabito, long? diaSemanaHabitoUID, TimeSpan horarioInicio, TimeSpan horarioTermino);
    }
}
