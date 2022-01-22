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
                    lista.Add(new VMModalidade(cadaModalidade));
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

                var model = new VMModalidade(modalidade);

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