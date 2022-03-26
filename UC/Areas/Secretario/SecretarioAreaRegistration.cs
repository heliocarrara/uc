using System.Web.Mvc;

namespace UC.Areas.Secretario
{
    public class SecretarioAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Secretario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Secretario_default",
                url: "Secretario/{controller}/{action}/{id}",
                defaults: new { controller = "Painel", action = "Detalhes", id = UrlParameter.Optional }
            );
        }
    }
}