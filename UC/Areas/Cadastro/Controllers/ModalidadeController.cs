using System;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class ModalidadeController: BaseController
    {
        const string formulario = "FormularioModalidade";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Nova()
        {
            try
            {
                var model = new VMFormModalidade();

                return View(formulario, model);
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Editar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Find(modalidadeUID);

                var model = new VMFormModalidade(modalidade);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Find(modalidadeUID);

                modalidade.ativa = false;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.Modalidade + " foi excluida com sucesso!");
                
                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Modalidade", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Reciclar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Find(modalidadeUID);

                modalidade.ativa = true;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.Modalidade + " está de volta!");

                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Modalidade", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Desativar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Find(modalidadeUID);

                modalidade.disponivel = false;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.Modalidade + " foi desativada com sucesso!");
                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Modalidade", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Ativar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.ModalidadeSet.Find(modalidadeUID);

                modalidade.disponivel = true;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.Modalidade + " está de volta!");

                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Modalidade", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormModalidade form)
        {
            try
            {
                if (form.modalidadeUID > 0)
                {
                    var modalidade = idbucContext.ModalidadeSet.Find(form.modalidadeUID);

                    modalidade.Modalidade = form.Modalidade;
                    modalidade.tipoModalidade = form.tipoModalidade;
                    modalidade.Descricao = form.Descricao;
                    modalidade.disponivel = form.disponivel;
                    modalidade.ValorInscrição = form.ValorInscrição;
                    modalidade.ValorMensalidade = form.ValorMensalidade;
                    modalidade.ativa = form.ativa;

                    AddMessage(UserMessageType.success, "A modalidade " + modalidade.Modalidade + " foi alterada com sucesso!");

                    idbucContext.SaveChanges();
                }
                else
                {
                    var novaModalidade = new ModalidadeSet
                    {
                        modalidadeUID = form.modalidadeUID,
                        Modalidade = form.Modalidade,
                        tipoModalidade = form.tipoModalidade,
                        Descricao = form.Descricao,
                        disponivel = form.disponivel,
                        ValorInscrição = form.ValorInscrição,
                        ValorMensalidade = form.ValorMensalidade,
                        ativa = true
                    };

                    idbucContext.ModalidadeSet.Add(novaModalidade);

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "A modalidade " + form.Modalidade + " foi criada com sucesso!");
                }

                return RedirectToAction("Lista", "Modalidade", new { Area = Utility.SimpleSessionPersister.UserRole});
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}