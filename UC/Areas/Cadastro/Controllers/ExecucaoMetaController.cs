using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;
using UC.Models.ViewModels.FormViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    public class ExecucaoMetaController : BaseController
    {
        private const string formulario = "FormularioExecucaoMeta";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index", new { Area = "Comum" });
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
                        tema = form.tema,
                        situacao = (int)SituacaoPasso.Inicio
                    };

                    idbucContext.ExecucaoMetas.Add(novoPasso);
                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo " + novoPasso.descricao + " foi incluído com sucesso!");
                }
                else
                {
                    var passo = idbucContext.ExecucaoMetas.Find(form.execucaoMetaUID);

                    if (form.dataInicio >= passo.Meta.dataInicio && form.dataInicio <= passo.Meta.dataObjetivo)
                    {
                        passo.dataInicio = form.dataInicio;
                    }

                    if (form.dataTermino >= passo.Meta.dataInicio && form.dataTermino <= passo.Meta.dataObjetivo)
                    {
                        passo.dataTermino = form.dataTermino;
                    }

                    passo.descricao = form.descricao;
                    
                    passo.tema = form.tema;

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo alterado com sucesso!");
                }

                return RedirectToAction("Detalhes", "Meta", new { metaUID = form.metaUID, Area = "Comum"});
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
                var registrosAtivos = idbucContext.ExecucaoMetas.Where(x => x.ativo && x.Meta.ativo && x.situacao == (int)SituacaoPasso.Em_Andamento).ToList();

                if (registrosAtivos.Count > 1)
                {
                    throw new Exception("Existem passos em execução. Finalize para continuar.");
                }

                var execucao = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                execucao.situacao = (int)SituacaoPasso.Em_Andamento;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A execução do passo foi iniciada.");

                return RedirectToAction("Execucao", "ExecucaoMeta", new { Area = "Comum"});
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult TrocarSituacao(long execucaoMetaUID, int situacaoPasso)
        {
            try
            {
                var execucao = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                var novoRegistro = new RegistroSituacaoExecucaoMeta
                {
                    ativo = true,
                    registroSituacaoExecucaoMetaUID = 0,
                    situacaoPasso = situacaoPasso,
                    execucaoMetaUID = execucaoMetaUID,
                    dataCriacao = DateTime.Now
                };

                idbucContext.RegistroSituacaoExecucaoMetas.Add(novoRegistro);

                execucao.situacao = situacaoPasso;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A situação da execução do passo foi alterada.");

                return RedirectToAction("Detalhes", "ExecucaoMeta", new { Area = "Comum", execucaoMetaUID = execucaoMetaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult AdicionarObservação(long execucaoMetaUID, string anotacao, bool incluirmeta)
        {
            try
            {
                var novoRegistro = new AnotacaoExecucaoMeta
                {
                    ativo = true,
                    anotacaoExecucaoMetaUID = 0,
                    execucaoMetaUID = execucaoMetaUID,
                    descricao = anotacao,
                    dataCriacao = DateTime.Now,
                    incluirNaMeta = incluirmeta
                };

                idbucContext.AnotacaoExecucaoMetas.Add(novoRegistro);

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Anotação incluída!");

                return RedirectToAction("Detalhes", "ExecucaoMeta", new { Area = "Comum", execucaoMetaUID = execucaoMetaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}