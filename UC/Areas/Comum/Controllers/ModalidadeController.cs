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
            return RedirectToAction("Index", "Home", new { Area = ""});
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
                var modalidade = idbucContext.Modalidades.FirstOrDefault(x => x.ativa && x.disponivel && x.modalidadeUID == modalidadeUID);

                var turmas = idbucContext.Turmas.Where(x => x.modalidadeUID == modalidadeUID).ToList();

                var model = new VMModalidade(modalidade, turmas);

                ViewBag.Message = "Detalhes Modalidade";

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}