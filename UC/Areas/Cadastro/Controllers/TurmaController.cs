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
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class TurmaController : BaseController
    {
        const string formulario = "FormularioTurma";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" }); ;
        }

        public ActionResult NovaTurma(long modalidadeUID)
        {
            try
            {
                var model = new VMFormTurma(modalidadeUID);

                ViewBag.Message = "Formulário de Turma";

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                return Index();
            }
        }

        public ActionResult Nova()
        {
            try
            {
                throw new NotImplementedException("Não implementado.");

                return Index();
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Editar(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                var model = new VMFormTurma(turma);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                turma.ativa = false;

                AddMessage(UserMessageType.success, "A turma: " + turma.turmaUID + " foi excluida com sucesso!");

                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Turma", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
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

                return RedirectToAction("Lixeira", "Turma", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
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

                return RedirectToAction("Lista", "Turma", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
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

                return RedirectToAction("Lixeira", "Turma", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormTurma form)
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

                return RedirectToAction("Lista", "Turma", new { Area = Utility.SimpleSessionPersister.UserRole, modalidadeUID = form.modalidadeUID});
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}