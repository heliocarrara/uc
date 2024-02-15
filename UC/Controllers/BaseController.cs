using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UC.Utility;

namespace UC.Controllers
{
    public abstract class BaseController : UserMessageController
    {
        #region INSTANCES

        protected Models.IUnityOfHelpers myUnityOfHelpers { get; private set; }

        protected Models.UCDBContext idbucContext { get; private set; }

        #endregion

        #region CONSTRUCTORS

        public BaseController()
        {
            this.idbucContext = new Models.UCDBContext();
            this.myUnityOfHelpers = new Models.UnityOfHelpers(new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext), this.idbucContext);
        }

        #endregion

        #region LOGIN PERSISTANCE

        protected string usuarioUID { get { return myUnityOfHelpers.UsuarioLogado.usuarioUID; } }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SimpleSessionPersister.IsLogged)
            {
                filterContext.HttpContext.User = new CustomPrincipal(
                    new CustomIdentity(
                        SimpleSessionPersister.Username,
                        SimpleSessionPersister.Id), SimpleSessionPersister.UserRole);
            }

            base.OnAuthorization(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            AddMessage(UserMessageType.error, "Exceção não tratada foi encontrada no sistema: [" + ExceptionMessage(filterContext.Exception) + "]");

            filterContext.Result = RedirectToAction("Index", "Index", new { Area = SimpleSessionPersister.UserRole });

            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }

        private string ExceptionMessage(Exception ex)
        {
            return ex.InnerException == null
                ? ex.Message
                : ex.Message + " (Exceção interna: " + ExceptionMessage(ex.InnerException) + ")";
        }

        #endregion
    }
}