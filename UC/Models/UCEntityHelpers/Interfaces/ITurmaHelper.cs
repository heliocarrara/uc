using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface ITurmaHelper
    {
        string GetNomeTurma(Turma turma);
        string GetDiasDaSemana(Turma turma);
    }
}
