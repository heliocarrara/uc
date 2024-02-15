using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;
using UC.Models.ViewModels;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Areas.Cadastro.Controllers
{
    public class ExecucaoMetaController : BaseController
    {
        private long? metaUID, execucaoMetaUID;
        private const string formulario = "FormularioExecucaoMeta";
        public ActionResult Index()
        {
            if (execucaoMetaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "ExecucaoMeta", new { Area = "Comum", execucaoMetaUID = execucaoMetaUID.Value });
            }

            if (metaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Meta", new { metaUID = metaUID.Value, Area = "Comum" });
            }

            return RedirectToAction("DetalharDia", "Cronograma", new { Area = "Comum" });
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
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                var model = new VMFormExecucaoMeta(myUnityOfHelpers, meta);

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
                if (form.metaUID == 0)
                {
                    throw new Exception("Meta não selecionada.");
                }

                this.metaUID = form.metaUID;

                var meta = idbucContext.Metas.Find(form.metaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                if (form.dataInicio > form.dataTermino)
                {
                    throw new Exception("Data de Início maior que a de término.");
                }

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
                    this.execucaoMetaUID = novoPasso.execucaoMetaUID;
                }
                else
                {
                    this.execucaoMetaUID = form.execucaoMetaUID;
                    var passo = idbucContext.ExecucaoMetas.Find(form.execucaoMetaUID);


                    if (form.dataInicio < passo.Meta.dataInicio)
                    {
                        throw new Exception("Data de Início está anterior à meta.");
                    }

                    if (form.dataTermino > passo.Meta.dataObjetivo)
                    {
                        throw new Exception("Data de Término ultrapassou à meta.");
                    }

                    passo.dataInicio = form.dataInicio;
                    passo.dataTermino = form.dataTermino;
                    passo.metaUID = form.metaUID > 0 ? form.metaUID : passo.metaUID;

                    passo.descricao = form.descricao;

                    passo.tema = form.tema;

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "Passo alterado com sucesso!");

                    if (passo.dataInicio.Date == DateTime.Today)
                    {
                        return RedirectToAction("DetalharDia", "Cronograma", new { Area = "Comum" });
                    }
                }

                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("NovaAtividade");
            }
        }
        public ActionResult Editar(long execucaoMetaUID)
        {
            try
            {
                this.execucaoMetaUID = execucaoMetaUID;
                var passo = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                if (passo == null || !passo.ativo)
                {
                    throw new Exception("Passo não encontrado");
                }

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(passo.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                if (passo.situacao == (int)SituacaoPasso.Concluido)
                {
                    throw new Exception("Passo concluído já");
                }

                var model = new VMFormExecucaoMeta(myUnityOfHelpers, passo);

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
                this.execucaoMetaUID = execucaoMetaUID;
                var passo = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                if (passo == null)
                {
                    throw new Exception("Passo não encontrado");
                }

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(passo.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                passo.ativo = false;

                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Passo excluído com sucesso da meta " + passo.Meta.nome);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
                return Index();
        }
        public ActionResult Iniciar(long execucaoMetaUID)
        {
            try
            {
                this.execucaoMetaUID = execucaoMetaUID;
                var registrosAtivos = idbucContext.ExecucaoMetas.Where(x => x.ativo && x.Meta.ativo && x.situacao == (int)SituacaoPasso.Em_Andamento).ToList();

                if (registrosAtivos.Count > 1)
                {
                    throw new Exception("Existem passos em execução. Finalize para continuar.");
                }

                var execucao = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(execucao.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                execucao.situacao = (int)SituacaoPasso.Em_Andamento;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A execução do passo foi iniciada.");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
                return Index();
        }
        public ActionResult TrocarSituacao(long execucaoMetaUID, int situacaoPasso)
        {
            try
            {
                this.execucaoMetaUID = execucaoMetaUID;
                var execucao = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(execucao.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

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

                switch ((SituacaoPasso)situacaoPasso)
                {
                    case SituacaoPasso.Concluido:
                        AddMessage(UserMessageType.success, "O Passo foi concluído!");
                        return RedirectToAction("DetalharDia", "Cronograma", new { Area = "Comum" });
                    default:
                        break;
                }

                AddMessage(UserMessageType.success, "A situação da execução do passo foi alterada.");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
                return Index();
        }
        public ActionResult AdicionarObservação(long execucaoMetaUID, string anotacao, bool incluirmeta)
        {
            try
            {
                this.execucaoMetaUID = execucaoMetaUID;
                var execucaoMeta = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(execucaoMeta.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

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
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
            return Index();
        }

        public ActionResult NovaAtividade()
        {
            try
            {
                var model = new VMFormExecucaoMeta(myUnityOfHelpers);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Duplicar(long execucaoMetaUID)
        {
            try
            {
                this.execucaoMetaUID = execucaoMetaUID;
                var passo = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                var model = new VMFormExecucaoMeta(myUnityOfHelpers, passo);

                model.execucaoMetaUID = 0;
                var duracao = model.dataTermino.Subtract(model.dataInicio);

                if (model.dataInicio < DateTime.Now)
                {
                    model.dataInicio = DateTime.Now;
                    model.dataTermino = model.dataInicio.AddMinutes(duracao.TotalMinutes);
                }

                ModelState.Remove("execucaoMetaUID");

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GerarExecucaoMeta(long horarioHabitoUID, DateTime dia)
        {
            try
            {
                var horarioHabito = idbucContext.HorariosHabito.Find(horarioHabitoUID);

                var habito = horarioHabito.cicloHabitoUID.HasValue
                    ? horarioHabito.CicloHabito.Habito
                    : horarioHabito.DiaSemanaHabito.Habito;

                UserMessage message;
                if (!myUnityOfHelpers.Metas.PossoAlterar(habito.Meta, out message))
                {
                    throw new Exception("Somente o dono da meta pode alterar!");
                }

                var dataInicio = new DateTime(dia.Year, dia.Month, dia.Day, horarioHabito.HorarioInicio.Hours, horarioHabito.HorarioInicio.Minutes, 0);
                var dataTermino = new DateTime(dia.Year, dia.Month, dia.Day, horarioHabito.HorarioTermino.Hours, horarioHabito.HorarioTermino.Minutes, 0);

                var novaExecucao = new ExecucaoMeta
                {
                    execucaoMetaUID = 0,
                    ativo = true,
                    descricao = habito.Descricao,
                    dataInicio = dataInicio,
                    dataTermino = dataTermino,
                    metaUID = habito.metaUID,
                    ordemPasso = 0,
                    situacao = (int)SituacaoPasso.Inicio,
                    horarioHabitoUID = horarioHabitoUID
                };

                idbucContext.ExecucaoMetas.Add(novaExecucao);
                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Passo " + novaExecucao.descricao + " foi incluído com sucesso!");
                this.execucaoMetaUID = novaExecucao.execucaoMetaUID;
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
            return Index();
        }
    }
}