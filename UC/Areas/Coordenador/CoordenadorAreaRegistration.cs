using System.Web.Mvc;

namespace UC.Areas.Coordenador
{
    public class CoordenadorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Coordenador";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Coordenador_default",
                url: "Coordenador/{controller}/{action}/{id}",
                defaults: new { controller = "Painel", action = "Detalhes", id = UrlParameter.Optional }
            );
        }
    }
}