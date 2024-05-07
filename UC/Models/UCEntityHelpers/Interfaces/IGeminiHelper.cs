using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UC.Utility;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface IGeminiHelper
    {
        bool EnviarRequisicao(string prompt, out string resultado);

        Task<string> EnviarRequisicaoAsync(string prompt);
    }
}
