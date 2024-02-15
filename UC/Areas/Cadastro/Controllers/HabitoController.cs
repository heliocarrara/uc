using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Areas.Cadastro.Controllers
{
    public class HabitoController : BaseController
    {
        private const string formulario = "FormularioHabito";
        private long? metaUID, habitoUID;
        public ActionResult Index()
        {
            if (metaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Meta", new { metaUID = metaUID.Value, Area = "Comum" });
            }

            if(habitoUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Habito", new { habitoUID = habitoUID.Value, Area = "Comum" });
            }

            return RedirectToAction("Index", "Index", new { Area = "Comum" });
        }
        public ActionResult Novo(long metaUID)
        {
            try
            {
                this.metaUID = metaUID;

                var meta = idbucContext.Metas.Find(metaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(meta, out message))
                {
                    throw new Exception(message.message);
                }

                var model = new VMFormHabito(myUnityOfHelpers, meta);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult NovoHabitoUsuario()
        {
            try
            {
                var model = new VMFormHabito(myUnityOfHelpers);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult GravarFormulario(VMFormHabito form, string returnUrl)
        {
            try
            {
                if (form.Habito == null)
                {
                    throw new Exception("Erro ao criar hábito.");
                }

                if (form.Habito.metaUID == 0)
                {
                    throw new Exception("Meta não selecionada.");
                }

                this.metaUID = form.Habito.metaUID;

                var meta = idbucContext.Metas.Find(form.Habito.metaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(meta, out message))
                {
                    throw new Exception(message.message);
                }

                if (form.Habito.habitoUID == 0)
                {
                    form.Habito.ativo = true;
                    form.Habito.DataCriacao = DateTime.Now;
                    form.Habito.DataAlteracao = DateTime.Now;

                    idbucContext.Habitos.Add(form.Habito);
                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Hábito " + form.Habito.Descricao + " foi incluído com sucesso!");
                }
                else
                {
                    this.habitoUID = form.Habito.habitoUID;

                    var habito = idbucContext.Habitos.Find(form.Habito.habitoUID);

                    habito.metaUID = form.Habito.metaUID;
                    habito.Descricao = form.Habito.Descricao;
                    habito.TipoGatilho = form.Habito.TipoGatilho;

                    habito.DataAlteracao = DateTime.Now;

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return Index();
        }
        public ActionResult Editar(long habitoUID)
        {
            try
            {
                this.habitoUID = habitoUID;

                var habito = idbucContext.Habitos.Find(habitoUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                var model = new VMFormHabito(myUnityOfHelpers, habito);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult Excluir(long habitoUID)
        {
            try
            {
                this.habitoUID = habitoUID;

                var habito = idbucContext.Habitos.Find(habitoUID);
                this.metaUID = habito.metaUID;

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                habito.ativo = false;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Hábito excluído com sucesso!");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return Index();
        }
    }
}