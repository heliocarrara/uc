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
    public class CicloHabitoController : BaseController
    {
        private const string formulario = "FormularioCicloHabito";
        private long? habitoUID;
        public ActionResult Index()
        {
            if(habitoUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Habito", new { habitoUID = habitoUID.Value, Area = "Comum" });
            }

            return RedirectToAction("Index", "Index", new { Area = "Comum" });
        }
        public ActionResult Novo(long? habitoUID, long? cicloHabitoUID)
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

                var model = new VMFormCicloHabito(myUnityOfHelpers, habito);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormCicloHabito form)
        {
            try
            {
                this.habitoUID = form.habitoUID;

                var habito = idbucContext.Habitos.Find(form.habitoUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                myUnityOfHelpers.CiclosHabitos.AtualizarCicloHabito(form, out message);

                AddMessage(UserMessageType.success, message);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return Index();
        }
        public ActionResult Editar(long horarioHabitoUID)
        {
            try
            {
                var horarioHabito = idbucContext.HorariosHabito.Find(horarioHabitoUID);

                this.habitoUID = horarioHabito.CicloHabito.habitoUID;

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(horarioHabito.CicloHabito.Habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                var model = new VMFormCicloHabito(myUnityOfHelpers, horarioHabito);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult ExcluirHorario(long horarioHabitoUID)
        {
            try
            {
                var horarioHabito = idbucContext.HorariosHabito.Find(horarioHabitoUID);

                this.habitoUID = horarioHabito.CicloHabito.habitoUID;

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(horarioHabito.CicloHabito.Habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                horarioHabito.Ativo = false;

                if (!horarioHabito.CicloHabito.HorariosHabito.Any(x => x.Ativo))
                {
                    horarioHabito.CicloHabito.ativo = false;
                }

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Horário do hábito excluído com sucesso!");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return Index();
        }
    }
}