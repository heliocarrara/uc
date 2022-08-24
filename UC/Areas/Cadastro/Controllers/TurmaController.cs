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
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class TurmaController : BaseController
    {
        const string formularioTurma = "FormularioTurma";
        const string formularioDiaSemana = "FormularioDiaSemana";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole});
        }

        public ActionResult NovaTurma(long modalidadeUID)
        {
            try
            {
                var model = new VMFormTurma(modalidadeUID);

                ViewBag.Message = "Formulário de Turma";

                return View(formularioTurma, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Detalhes", "Modalidade", new { Area = "Comum", modalidadeUID  = modalidadeUID });

            }
        }

        public ActionResult Editar(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                var model = new VMFormTurma(turma);

                return View(formularioTurma, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });

            }
        }

        public ActionResult ExcluirTurma(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                turma.ativa = false;

                AddMessage(UserMessageType.success, "A turma: " + turma.Modalidade.nome + " de " + turma.HorarioInicio.ToShortTimeString() + " foi excluída com sucesso!");

                idbucContext.SaveChanges();
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });

            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
        }

        public ActionResult ExcluirDia(long diasemanaturmaUID)
        {
            try
            {
                var DiaSemana = idbucContext.DiaSemanaTurmas.Find(diasemanaturmaUID);

                DiaSemana.ativo = false;

                AddMessage(UserMessageType.success, "O dia: " + ((DiaSemanal)DiaSemana.diaSemanal).ToFriendlyString() + " foi excluido com sucesso!");

                idbucContext.SaveChanges();

                return RedirectToAction("Detalhes", "Turma", new { turmaUID = DiaSemana.turmaUID, Area = "Comum" });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
        }

        public ActionResult Reciclar(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                turma.ativa = true;
                AddMessage(UserMessageType.success, "A turma: " + turma.turmaUID + " está de volta!");

                idbucContext.SaveChanges();

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
        }

        public ActionResult Desativar(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                turma.disponivel = false;

                AddMessage(UserMessageType.success, "A turma: " + turma.turmaUID + " foi desativada com sucesso!");
                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });
            }
        }

        public ActionResult Ativar(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                turma.disponivel = true;

                AddMessage(UserMessageType.success, "A turma: " + turma.turmaUID + " está de volta!");

                idbucContext.SaveChanges();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });
        }

        public ActionResult NovoDiaSemanal(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                var model = new VMFormDiaDaSemanaTurma(myUnityOfHelpers, turma);

                return View(formularioDiaSemana, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }
            return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });
        }

        public ActionResult GravarFormularioDiaDaSemana(VMFormDiaDaSemanaTurma form)
        {
            try
            {
                if (!form.diaSemanal.HasValue)
                {
                    throw new Exception("Selecione o Dia Semanal desejado.");
                }

                if (form.turmaUID <= 0)
                {
                    throw new Exception("Erro ao carregar turma.");
                }

                if (idbucContext.DiaSemanaTurmas.Any(x => x.ativo && x.turmaUID == form.turmaUID && x.diaSemanal == form.diaSemanal.Value))
                {
                    throw new Exception("Já existe este dia semanal para esta turma.");
                }

                var novo = new DiaSemanaTurma
                {
                    diasemanaturmaUID = 0,
                    ativo = true,
                    diaSemanal = form.diaSemanal.Value,
                    turmaUID = form.turmaUID
                };

                idbucContext.DiaSemanaTurmas.Add(novo);

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Cadastro de dia semanal foi realizado com sucesso!");

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = form.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);

                if (form.turmaUID > 0)
                {
                    return NovoDiaSemanal(form.turmaUID);
                }

                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
        }

        public ActionResult GravarFormularioTurma(VMFormTurma form)
        {
            try
            {
                var horarioInicio = new DateTime(DateTime.Now.Year,1,1); var horarioTermino = new DateTime(DateTime.Now.Year, 1, 1);

                horarioInicio = horarioInicio.AddMinutes(form.minutoInicio);
                horarioInicio = horarioInicio.AddHours(form.horaInicio);

                horarioTermino = horarioTermino.AddMinutes(form.minutoTermino);
                horarioTermino = horarioTermino.AddHours(form.horaTermino);

                if (!form.turmaUID.HasValue || form.turmaUID.Value > 0)
                {
                    var turma = new Turma()
                    {
                        turmaUID = 0,
                        ativa = true,
                        Descricao = form.descricao,
                        Vagas = form.vagas,
                        disponivel = form.disponivel,
                        modalidadeUID = form.modalidadeUID,
                        HorarioInicio = horarioInicio,
                        DuracaoAula = horarioTermino.Subtract(horarioInicio).TotalMinutes
                    };

                    idbucContext.Turmas.Add(turma);

                    idbucContext.SaveChanges();
                }
                else
                {
                    var turma = idbucContext.Turmas.Find(form.turmaUID.Value);

                    turma.Descricao = form.descricao;
                    turma.disponivel = form.disponivel;
                    turma.Vagas = form.vagas;
                    turma.modalidadeUID = form.modalidadeUID;

                    turma.HorarioInicio = horarioInicio;
                    turma.DuracaoAula = horarioTermino.Subtract(horarioInicio).TotalMinutes;

                    idbucContext.SaveChanges();
                }

                ViewBag.Message = "Turma Cadastrada com Sucesso!";
                AddMessage(UserMessageType.success, "Turma Cadastrada com Sucesso!!!");

                return RedirectToAction("Detalhes", "Modalidadde", new { Area = "Comum", modalidadeUID = form.modalidadeUID});
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Lista", "Turma", new { Area = "Comum" });
            }
        }
    }
}