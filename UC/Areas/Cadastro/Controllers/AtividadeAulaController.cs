using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class AtividadeAulaController : BaseController
    {
        const string formularioAtividadeAula = "FormularioAtividadeAula";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Nova(long aulaUID)
        {
            try
            {
                var aula = idbucContext.Aulas.Find(aulaUID);
                if (aula == null)
                {
                    throw new Exception("Erro ao carregar aula.");
                }

                var model = new VMFormAtividadeAula(aula);

                return View(formularioAtividadeAula, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID, Area = "Comum" });
        }

        public ActionResult GravarFormularioAtividadeAula(VMFormAtividadeAula form)
        {
            try
            {

                var novaAtividade = new Models.AtividadeAula
                {
                    atividadeaulaUID = 0,
                    aulaUID = form.aulaUID,
                    ativa = true,
                    aprovado = false,
                    descricao = form.descricao,
                    titulo = form.titulo,
                    duracaoMin = form.duracaoMin,
                    ordem = 0
                };

                idbucContext.AtividadeAulas.Add(novaAtividade);

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Nova atividade foi incluída com sucesso!");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Detalhes", "Aula", new { aulaUID = form.aulaUID, Area = "Comum" });
        }

        public ActionResult MudarSituacao(long atividadeaulaUID)
        {
            long? aulaUID = null;
            try
            {
                var atividade = idbucContext.AtividadeAulas.Find(atividadeaulaUID);

                aulaUID = atividade.aulaUID;

                atividade.ativa = !atividade.ativa;

                idbucContext.SaveChanges();

                if (atividade.ativa)
                {
                    AddMessage(UserMessageType.success, "A atividade foi reciclada com sucesso!");
                }
                else
                {
                    AddMessage(UserMessageType.success, "A atividade foi excluída com sucesso!");
                }
                
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (aulaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID.Value, Area = "Comum" });
            }

            return Index();
        }

        public ActionResult Aprovar(long atividadeaulaUID)
        {
            long? aulaUID = null;
            try
            {
                var atividade = idbucContext.AtividadeAulas.Find(atividadeaulaUID);

                aulaUID = atividade.aulaUID;

                atividade.aprovado = true;

                idbucContext.SaveChanges();

                if (atividade.aprovado)
                {
                    AddMessage(UserMessageType.success, "A atividade foi aprovada com sucesso!");
                }
                else
                {
                    AddMessage(UserMessageType.success, "A atividade foi excluída com sucesso!");
                }

            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (aulaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID.Value, Area = "Comum" });
            }

            return Index();
        }
    }
}