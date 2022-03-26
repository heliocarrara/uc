using System.Web.Mvc;

namespace UC.Areas.Comum
{
    public class ComumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Comum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Comum_default",
                url: "Comum/{controller}/{action}/{id}",
                defaults: new { controller = "Painel", action = "Detalhes", id = UrlParameter.Optional }
            );
        }
    }
}