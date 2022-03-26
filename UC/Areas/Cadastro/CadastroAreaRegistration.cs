using System.Web.Mvc;

namespace UC.Areas.Cadastro
{
    public class CadastroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cadastro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Cadastro_default",
                url: "Cadastro/{controller}/{action}/{id}",
                defaults: new { controller = "Painel", action = "Detalhes", id = UrlParameter.Optional }
            );
        }
    }
}