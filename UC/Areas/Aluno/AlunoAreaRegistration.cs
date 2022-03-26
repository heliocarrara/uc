using System.Web.Mvc;

namespace UC.Areas.Aluno
{
    public class AlunoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Aluno";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Aluno_default",
                url: "Aluno/{controller}/{action}/{id}",
                defaults: new { controller = "Painel", action = "Detalhes", id = UrlParameter.Optional }
            );
        }
    }
}