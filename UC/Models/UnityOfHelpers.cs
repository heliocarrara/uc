using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Utility;
//using UC.Models.ViewModels.ListViewModels;
using UC.Models.UCEntityHelpers;
using Microsoft.EntityFrameworkCore;
using UC.Models;
using UC.Models.UCEntityHelpers.Interfaces;

namespace UC.Models
{
    public class UnityOfHelpers : IUnityOfHelpers
    {
        #region PUBLIC GET INSTANCES

        public UCDBContext idbucContext { get { return this._db; } }

        public UrlHelper urlHelper { get { return this._url; } }

        #endregion

        #region PRIVATE INSTANCES

        private UrlHelper _url;
        private UCDBContext _db;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Método construtor para a coleção de instâncias.
        /// </summary>
        /// <param name="_url">Url Helper para gerar strings de acesso na aplicação.</param>
        /// <param name="_db">Contexto de conexão do banco de dados.</param>
        /// <param name="_services">Unidade de gerenciamento de acesso aos serviços WCF.</param>
        public UnityOfHelpers(UrlHelper _url, UCDBContext _db)
        {
            this._url = _url;
            this._db = _db;
        }

        #endregion

        #region PUBLIC GET HELPERS

        public ILoggedUserHelper UsuarioLogado { get { if (usuarioLogado == null) { usuarioLogado = new LoggedUserHelper(_url, _db, this); } return UsuarioLogado; } }
        public ISelectListHelper SelectLists { get { if (selectLists == null) { selectLists = new SelectListHelper(_url, _db, this); } return selectLists; } }
        public IMetaHelper Metas { get { if (metas == null) { metas = new MetaHelper(_url, _db, this); } return metas; } }
        public ICicloHabitoHelper CiclosHabitos { get { if (ciclosHabitos == null) { ciclosHabitos = new CicloHabitoHelper(_url, _db, this); } return ciclosHabitos; } }
        #endregion
        #region PRIVATE HELPERS' INSTANCES

        private LoggedUserHelper usuarioLogado { get; set; }
        private SelectListHelper selectLists { get; set; }
        private MetaHelper metas { get; set; }
        private CicloHabitoHelper ciclosHabitos { get; set; }
        #endregion
    }
}