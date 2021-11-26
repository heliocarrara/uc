using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;

namespace UC.Models.UCEntityHelpers
{
    public class BaseHelper
    {
        protected UrlHelper urlHelper { get; set; }

        protected UCDBContext idbucContext { get; set; }

        protected IUnityOfHelpers unityOfHelpers { get; set; }

        //protected IUnityOfServices unityOfServices { get; set; }

        public BaseHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers)//, IUnityOfServices _services)
        {
            this.urlHelper = _url;
            this.idbucContext = _db;
            this.unityOfHelpers = _helpers;
            //this.unityOfServices = _services;
        }
    }
}