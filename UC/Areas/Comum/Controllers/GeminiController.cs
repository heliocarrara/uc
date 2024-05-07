using System;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Comum.Controllers
{
    [Authorize]
    public class GeminiController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }

        public ActionResult RequisicaoTexto(string prompt)
        {
            return View(new VMFormRequisicaoGemini(prompt));
        }

        public ActionResult Enviar(string prompt)
        {
            try
            {
                string resultado;

                //myUnityOfHelpers.GeminiAI.EnviarRequisicao(prompt, out resultado);

                var result = myUnityOfHelpers.GeminiAI.EnviarRequisicaoAsync(prompt);

                resultado = result.Result;

                var model = new VMFormRequisicaoGemini(prompt, resultado);

                return View("RequisicaoTexto", model);
            }
            catch (Exception ex) 
            {
                AddMessage(UserMessageType.error, ex.Message);
                return RequisicaoTexto(prompt);
            }
        }
    }
}