using System;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
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
                var model = new VMFormModalidade(myUnityOfHelpers);

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
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                var model = new VMFormModalidade(myUnityOfHelpers, modalidade);

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
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                modalidade.ativa = false;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.nome + " foi excluida com sucesso!");
                
                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Modalidade", new { Area = "Comum" });
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
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                modalidade.ativa = true;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.nome + " está de volta!");

                idbucContext.SaveChanges();

                return RedirectToAction("Detalhes", "Modalidade", new { Area = "Comum", modalidadeUID = modalidade }); 
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Lista", "Modalidade", new { Area = "Comum" });
        }

        public ActionResult Desativar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                modalidade.disponivel = false;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.nome + " foi desativada com sucesso!");
                idbucContext.SaveChanges();                
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Lista", "Modalidade", new { Area = "Comum" });
        }

        public ActionResult Ativar(long modalidadeUID)
        {
            try
            {
                var modalidade = idbucContext.Modalidades.Find(modalidadeUID);

                modalidade.disponivel = true;

                AddMessage(UserMessageType.success, "A modalidade " + modalidade.nome + " está de volta!");

                idbucContext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Detalhes", "Modalidade", new { Area = "Comum", modalidadeUID = modalidadeUID });
        }

        public ActionResult GravarFormulario(VMFormModalidade form)
        {
            long? modalidadeUID = null;
            try
            {
                if (!form.tipoModalidade.HasValue)
                {
                    throw new Exception("Tipo de modalidade não selecionada.");
                }

                if (form.modalidadeUID > 0)
                {
                    modalidadeUID = form.modalidadeUID;
                    var modalidade = idbucContext.Modalidades.Find(form.modalidadeUID);

                    modalidade.nome = ((TipoModalidade)form.tipoModalidade.Value).ToFriendlyString();
                    modalidade.tipoModalidade = form.tipoModalidade.Value;
                    modalidade.Descricao = form.Descricao;
                    modalidade.ValorInscrição = form.ValorInscrição;
                    modalidade.ValorMensalidade = form.ValorMensalidade;

                    AddMessage(UserMessageType.success, "A modalidade " + modalidade.nome + " foi alterada com sucesso!");

                    idbucContext.SaveChanges();
                }
                else
                {
                    var novaModalidade = new Modalidade
                    {
                        modalidadeUID = form.modalidadeUID,
                        nome = ((TipoModalidade)form.tipoModalidade.Value).ToFriendlyString(),
                        tipoModalidade = form.tipoModalidade.Value,
                        Descricao = !string.IsNullOrWhiteSpace(form.Descricao) ? form.Descricao : string.Empty,
                        disponivel = form.disponivel,
                        ValorInscrição = form.ValorInscrição,
                        ValorMensalidade = form.ValorMensalidade,
                        ativa = true
                    };

                    idbucContext.Modalidades.Add(novaModalidade);

                    idbucContext.SaveChanges();
                    modalidadeUID = novaModalidade.modalidadeUID;
                    AddMessage(UserMessageType.success, "A modalidade " + form.nome + " foi criada com sucesso!");
                }

            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (modalidadeUID.HasValue && modalidadeUID > 0)
            {
                return RedirectToAction("Detalhes", "Modalidade", new { Area = "Comum", modalidadeUID = modalidadeUID });
            }

            return RedirectToAction("Lista", "Modalidade", new { Area = "Comum" });
        }
    }
}