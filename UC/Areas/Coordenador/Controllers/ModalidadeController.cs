﻿using System;
using System.Linq;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class ModalidadeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Lista()
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Where(x => x.ativa && x.disponivel).ToList();

                var model = new VMListModalidade(modalidade);

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
                var modalidade = idbucContext.ModalidadeSet.Where(x => x.ativa == false || x.disponivel == false).ToList();

                var model = new VMListModalidade(modalidade);

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