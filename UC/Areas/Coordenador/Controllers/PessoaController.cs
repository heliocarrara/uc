using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class PessoaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel");
        }
        public ActionResult Lista()
        {
            try
            {
                var model = new List<VMPessoa>();

                var pessoas = idbucContext.Pessoas.ToList();

                foreach (var cadaPessoa in pessoas)
                {
                    model.Add(new VMPessoa(cadaPessoa));
                }

                model = model.OrderBy(x => x.nome).ToList();

                ViewBag.Message = "Pessoas";

                return View("ListaPessoas", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult ListaPermissao(long pessoaUID)
        {
            try
            {
                return RedirectToAction("ListaPorPessoa", "Permissao", new { Area = Utility.SimpleSessionPersister.UserRole, pessoaUID = pessoaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}