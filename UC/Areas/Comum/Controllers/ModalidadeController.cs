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
            return View("Index");
        }

        public ActionResult Lista()
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Where(x => x.ativa && x.disponivel).ToList();

                var model = new VMListModalidade(modalidade);

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
                var modalidade = idbucContext.ModalidadeSet.FirstOrDefault(x => x.ativa && x.disponivel && x.modalidadeUID == modalidadeUID);

                var model = new VMModalidade(modalidade);

                ViewBag.Message = "Detalhes Modalidade";

                return View(model);
            }
            catch (Exception ex)
            {
                return Index();
            }
        }
    }
}