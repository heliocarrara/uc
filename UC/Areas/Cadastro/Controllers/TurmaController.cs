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
    public class TurmaController : BaseController
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult NovaTurma(long modalidadeUID)
        {
            try
            {
                var model = new VMFormTurma(modalidadeUID);

                ViewBag.Message = "Formulários";

                return View("FormularioTurma", model);
            }
            catch (Exception ex)
            {
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
                    var turma = new TurmaSet()
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

                    idbucContext.TurmaSet.Add(turma);

                    idbucContext.SaveChanges();
                }
                else
                {
                    var turma = idbucContext.TurmaSet.Find(form.turmaUID.Value);

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

                return RedirectToAction("Detalhes", "Modalidade", new { Area = "Comum", modalidadeUID = form.modalidadeUID});
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}