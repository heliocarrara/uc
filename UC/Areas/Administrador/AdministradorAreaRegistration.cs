using System.Web.Mvc;

namespace UC.Areas.Administrador
{
    public class AdministradorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrador";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrador_default",
                "Administrador/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "UC.Areas.Administrador.Controllers" }
            );
        }
    }
}