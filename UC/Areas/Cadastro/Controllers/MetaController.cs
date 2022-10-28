using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    public class MetaController: BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Index", new { Area = "Comum" });
        }

        public ActionResult Nova()
        {
            try
            {
                var model = new VMFormMeta();

                return View(model);
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormMeta form)
        {
            try
            {
                var novaMeta = new Meta
                {
                    ativo = true,
                    metaUID = 0,
                    nome = form.nome,
                    motivo = form.motivo,
                    dataInicio = form.dataInicio,
                    dataObjetivo = form.dataTermino,
                    ordemPrioridade = 0
                };

                idbucContext.Metas.Add(novaMeta);
                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Meta " + novaMeta.nome + " foi incluída com sucesso!");
                return Index();
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return View("Nova", form);
            }
        }

        public ActionResult Editar(long metaUID)
        {
            try
            {
                throw new Exception("Ação não criada. Ta na hora.");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult Excluir(long metaUID)
        {
            try
            {
                throw new Exception("Ação não criada. Ta na hora.");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult OrganizarPassos (long metaUID)
        {
            try
            {
                var meta = idbucContext.Metas.Find(metaUID);

                if (meta == null)
                {
                    throw new Exception("Meta não encontrada.");
                }

                var passos = meta.ExecucaoMetas.Where(x => x.ativo).ToList();

                passos = passos.OrderBy(x => x.dataInicio).ToList();

                for (int i = 0; i < passos.Count; i++)
                {
                    passos[i].ordemPasso = i + 1;
                }

                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Ordem dos passos da meta " + meta.nome + " foi alterada com sucesso!");
                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}