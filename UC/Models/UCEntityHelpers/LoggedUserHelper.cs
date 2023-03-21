using UC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.UCEntityHelpers
{

    public class LoggedUserHelper : BaseHelper, Interfaces.ILoggedUserHelper
    {
        #region PROPERTIES

        public string usuarioUID { get { return SimpleSessionPersister.Id; } }

        #endregion

        #region CONSTRUCTORS

        public LoggedUserHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion
    }
}