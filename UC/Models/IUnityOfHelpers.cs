using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UC.Models.UCEntityHelpers.Interfaces;

namespace UC.Models
{
    public interface IUnityOfHelpers
    {
        /// <summary>
        /// Contexto de conexão do Banco de Dados.
        /// </summary>
        UCDBContext idbucContext { get; }

        /// <summary>
        /// Construtor de URLs da aplicação.
        /// </summary>
        UrlHelper urlHelper { get; }

        ILoggedUserHelper UsuarioLogado { get; }
    }
}
