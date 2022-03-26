using UC.Models.UCEntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;
using UC.Controllers;

namespace UC.Areas.Comum.Controllers
{
    public class PessoaController : BaseController
    {
        public ActionResult Index()
        {
            if (Utility.SimpleSessionPersister.IsLogged)
            {
                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }

            return RedirectToAction("Index", "Home", new { Area = ""});
        }

        public ActionResult Detalhes(long pessoaUID)
        {
            try
            {
                var pessoa = idbucContext.Pessoas.Find(pessoaUID);

                if (pessoa == null)
                {
                    throw new Exception("Cadastro não encontrado.");
                }

                var model = new VMPessoa(myUnityOfHelpers, pessoa);

                ViewBag.Message = "Perfil de " + model.nome;

                return View("Detalhes", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult BuscarPeloCpf(string cpf)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(cpf))
                {
                    throw new Exception("Erro ao buscar cpf.");
                }

                var pessoa = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == cpf);

                if (pessoa == null)
                {
                    throw new Exception("Cadastro não encontrado.");
                }

                var model = new VMPessoa(myUnityOfHelpers, pessoa);

                ViewBag.Message = "Perfil de " + model.nome;

                return View("Detalhes", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}