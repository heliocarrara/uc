using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models.Enumerators;
using UC.Utility;

namespace UC.Models.UCEntityHelpers
{
    public class MetaHelper : BaseHelper, Interfaces.IMetaHelper
    {
        #region CONSTRUCTORS

        public MetaHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion
        #region METHODS

        public bool PossoAlterar(Meta meta, out UserMessage message)
        {
            try
            {
                message = new UserMessage("");
                return meta.usuarioUID == SimpleSessionPersister.usuarioUID;
            }
            catch (Exception ex)
            {
                message = new UserMessage(ex.Message);
                return false;
            }
        }
        #endregion
    }
}