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
    public class ModalidadeController : BaseController
    {
        public ActionResult Index()
        {
            if (Utility.SimpleSessionPersister.IsLogged)
            {
                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }

            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Lista()
        {
            try
            {
                var lista = new List<VMModalidade>();

                var modalidades = idbucContext.Modalidades.Where(x => x.ativa && x.disponivel).ToList();

                foreach (var cadaModalidade in modalidades)
                {
                    lista.Add(new VMModalidade(myUnityOfHelpers, cadaModalidade));
                }

                var model = new VMListModalidade(lista);

                ViewBag.Message = "Modalidades";

                return View(model);
            }
            catch (Exception ex)
            {
                return Index();
            }
        }

        public ActionResult Detalhes(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                if (modalidade == null || !modalidade.ativa)
                {
                    throw new Exception("Nenhum resultado encontrado");
                }

                var model = new VMModalidade(myUnityOfHelpers, modalidade);

                ViewBag.Message = "Detalhes Modalidade";

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
        public ActionResult Lixeira()
        {
            try
            {
                var lista = new List<VMModalidade>();

                var modalidades = idbucContext.Modalidades.Where(x => x.ativa == false || x.disponivel == false).ToList();

                foreach (var cadaModalidade in modalidades)
                {
                    lista.Add(new VMModalidade(myUnityOfHelpers, cadaModalidade));
                }

                var model = new VMListModalidade(lista);

                ViewBag.Message = "Modalidades desativadas";

                return View("Lista", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}