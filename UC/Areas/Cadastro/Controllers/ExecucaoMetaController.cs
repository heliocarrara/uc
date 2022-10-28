using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    public class ExecucaoMetaController : BaseController
    {
        private const string formulario = "FormularioExecucaoMeta";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Index", new { Area = "Comum" });
        }

        public ActionResult Novo(long metaUID)
        {
            try
            {
                var meta = idbucContext.Metas.Find(metaUID);

                var model = new VMFormExecucaoMeta(meta);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormExecucaoMeta form)
        {
            try
            {
                if (form.execucaoMetaUID == 0)
                {
                    var novoPasso = new Models.ExecucaoMeta
                    {
                        ativo = true,
                        execucaoMetaUID = 0,
                        metaUID = form.metaUID,
                        descricao = form.descricao,
                        dataInicio = form.dataInicio,
                        dataTermino = form.dataTermino,
                        ordemPasso = 0,
                        tema = form.tema
                    };

                    idbucContext.ExecucaoMetas.Add(novoPasso);
                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo " + novoPasso.descricao + " foi incluído com sucesso!");
                }
                else
                {
                    var passo = idbucContext.ExecucaoMetas.Find(form.execucaoMetaUID);

                    if (form.dataInicio >= passo.Meta.dataInicio && form.dataInicio <= passo.Meta.dataObjetivo.Value)
                    {
                        passo.dataInicio = form.dataInicio;
                    }

                    if (form.dataTermino >= passo.Meta.dataInicio.Value && form.dataTermino <= passo.Meta.dataObjetivo.Value)
                    {
                        passo.dataTermino = form.dataTermino;
                    }

                    passo.descricao = form.descricao;
                    
                    passo.tema = form.tema;

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo alterado com sucesso!");
                }

                return RedirectToAction("OrganizarPassos", "Meta", new { metaUID = form.metaUID, Area = "Cadastro"});
            }
            catch (Exception ex)
            {
                form.meta = idbucContext.Metas.Find(form.metaUID);
                AddMessage(UserMessageType.error, ex);
                return View(formulario, form);
            }
        }
        public ActionResult Editar(long execucaoMetaUID)
        {
            try
            {
                var passo = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                if (passo == null)
                {
                    throw new Exception("Passo não encontrado");
                }

                var model = new VMFormExecucaoMeta(passo);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult Excluir(long execucaoMetaUID)
        {
            try
            {
                var passo = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                if (passo == null)
                {
                    throw new Exception("Passo não encontrado");
                }

                passo.ativo = false;

                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Passo excluído com sucesso da meta " + passo.Meta.nome);

                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Iniciar(long execucaoMetaUID)
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

        public ActionResult Pausar(long execucaoMetaUID)
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
    }
}