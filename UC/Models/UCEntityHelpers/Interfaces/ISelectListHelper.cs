using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface ISelectListHelper
    {
        SelectList TiposDeModalidade(int? tipoModalidade);
        SelectList TiposDeLogin(int? tipoLogin);
        SelectList TurmasDisponiveis(long? turmaUID);
        SelectList DiasDaSemana(int? diaDaSemana);
    }
}
