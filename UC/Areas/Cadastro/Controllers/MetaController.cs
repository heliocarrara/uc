using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Areas.Cadastro.Controllers
{
    [Authorize]
    public class MetaController: BaseController
    {
        private const string formulario = "FormularioMeta";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index", new { Area = "Comum" });
        }

        public ActionResult Nova()
        {
            try
            {
                var model = new VMFormMeta(myUnityOfHelpers);

                return View(formulario, model);
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
                if (form.metaUID == 0)
                {
                    var novaMeta = new Meta
                    {
                        ativo = true,
                        metaUID = 0,
                        nome = form.nome,
                        motivo = form.motivo,
                        dataInicio = form.dataInicio,
                        dataObjetivo = form.dataTermino,
                        ordemPrioridade = 0,
                        tema = form.tema,
                        tipo = form.tipoMeta.Value,
                        subTipoMetaUID = form.subTipoMetaUID,
                        usuarioUID = SimpleSessionPersister.usuarioUID
                    };

                    idbucContext.Metas.Add(novaMeta);
                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Meta " + novaMeta.nome + " foi incluída com sucesso!");
                }
                else
                {
                    var meta = idbucContext.Metas.Find(form.metaUID);

                    meta.nome = form.nome;
                    meta.motivo = form.motivo;
                    meta.dataInicio = form.dataInicio;
                    meta.dataObjetivo = form.dataTermino;
                    meta.ordemPrioridade = form.ordem;
                    meta.tema = !string.IsNullOrWhiteSpace(form.tema) ? form.tema : meta.tema;
                    meta.tipo = form.tipoMeta.Value;
                    meta.subTipoMetaUID = form.subTipoMetaUID;

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Meta: " + meta.nome + " foi alterada com sucesso!");
                }

                return RedirectToAction("Lista", "Meta", new { Area = "Comum"});
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Nova();
            }
        }

        public ActionResult Editar(long metaUID)
        {
            try
            {
                var meta = idbucContext.Metas.Find(metaUID);

                if (meta == null)
                {
                    throw new Exception("Meta não encontrada.");
                }

                var model = new VMFormMeta(myUnityOfHelpers, meta);

                return View(formulario, model);
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
                var meta = idbucContext.Metas.Find(metaUID);

                if (meta == null)
                {
                    throw new Exception();
                }

                meta.ativo = false;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A meta: " + meta.nome + " foi excluída!");
                return Index();
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