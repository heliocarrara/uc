using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class ModalidadeController : BaseController
    {
        public ActionResult Index()
        {
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
                    var turmas = idbucContext.Turmas.Where(x => x.ativa && x.disponivel && x.modalidadeUID == cadaModalidade.modalidadeUID).ToList();

                    lista.Add(new VMModalidade(cadaModalidade, turmas));
                }

                var model = new VMListModalidade(lista);

                ViewBag.Message = "Modalidades";

                return View("ListaModalidade", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Lixeira()
        {
            try
            {
                var lista = new List<VMModalidade>();

                var modalidades = idbucContext.Modalidades.Where(x => x.ativa == false || x.disponivel == false).ToList();

                foreach (var cadaModalidade in modalidades)
                {
                    var turmas = idbucContext.Turmas.Where(x => x.ativa && x.disponivel && x.modalidadeUID == cadaModalidade.modalidadeUID).ToList();

                    lista.Add(new VMModalidade(cadaModalidade, turmas));
                }

                var model = new VMListModalidade(lista);

                ViewBag.Message = "Modalidades desativadas";

                return View("ListaModalidade", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}