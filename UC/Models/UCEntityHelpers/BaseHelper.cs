using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIEX.Models.SiexEntityHelpers
{
    public class BaseHelper
    {
        protected UrlHelper urlHelper { get; set; }

        protected DbContext idbucContext { get; set; }

        //protected IUnityOfHelpers unityOfHelpers { get; set; }

        //protected IUnityOfServices unityOfServices { get; set; }

        public BaseHelper(UrlHelper _url, DbContext _db)//, IUnityOfServices _services, IUnityOfHelpers _helpers)
        {
            this.urlHelper = _url;
            this.idbucContext = _db;
            //this.unityOfHelpers = _helpers;
            //this.unityOfServices = _services;
        }
    }
}