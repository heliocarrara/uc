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
    public class AulaController : BaseController
    {
        const string formularioAula = "FormularioAula";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Nova(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);
                if (turma == null)
                {
                    throw new Exception("Erro ao carregar turma.");
                }

                var model = new VMFormAula(turma);

                return View(formularioAula, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Detalhes", "Turma", new { turmaUID = turmaUID, Area = "Comum" });
            }
        }

        public ActionResult Editar(long aulaUID)
        {
            long? turmaUID = null;
            try
            {
                var aula = idbucContext.Aulas.Find(aulaUID);
                if (aula == null)
                {
                    throw new Exception("Erro ao carregar turma.");
                }

                turmaUID = aula.turmaUID;

                var model = new VMFormAula(aula);

                return View(formularioAula, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (turmaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Turma", new { turmaUID = turmaUID.Value, Area = "Comum" });
            }

            return Index();
        }

        public ActionResult GravarFormularioAula(VMFormAula form)
        {
            long? turmaUID = null;
            try
            {
                turmaUID = form.turmaUID;

                if (form.aulaUID > 0)
                {
                    var aula = idbucContext.Aulas.Find(form.aulaUID);

                    aula.aulaExtra = form.aulaExtra;
                    aula.dataRealizacao = new DateTime(form.dataRealizacao.Year, form.dataRealizacao.Month, form.dataRealizacao.Day, aula.Turma.HorarioInicio.Hour, aula.Turma.HorarioInicio.Minute, 0);
                    aula.duracaoMin = form.duracaoMin;

                    idbucContext.SaveChanges();

                    AddMessage(UserMessageType.success, "Aula alterada com sucesso!");
                }
                else
                {
                    var turma = idbucContext.Turmas.Find(form.turmaUID);
                    if (turma == null)
                    {
                        throw new Exception("Erro ao carregar turma.");
                    }

                    if (turma.Aulas.Any(x => x.dataRealizacao.DayOfYear == form.dataRealizacao.DayOfYear))
                    {
                        throw new Exception("Já existe uma aula cadastrada para este dia do ano e para esta turma.");
                    }

                    var diaDaSemana = (int)form.dataRealizacao.DayOfWeek;
                    var diaSemanal = turma.DiaSemanaTurmas.FirstOrDefault(x => x.ativo && x.diaSemanal == diaDaSemana);
                    if (diaSemanal == null)
                    {
                        throw new Exception("Este dia da semana não está disponível de acordo com os dias cadastrados na turma.");
                    }

                    var novoDia = new Models.Aula
                    {
                        aulaUID = 0,
                        ativa = true,
                        aulaExtra = form.aulaExtra,
                        dataRealizacao = new DateTime(form.dataRealizacao.Year, form.dataRealizacao.Month, form.dataRealizacao.Day, turma.HorarioInicio.Hour, turma.HorarioInicio.Minute, 0),
                        turmaUID = form.turmaUID,
                        duracaoMin = form.duracaoMin
                    };

                    idbucContext.Aulas.Add(novoDia);

                    idbucContext.SaveChanges();

                    AddMessage(UserMessageType.success, "Novo dia foi incluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (turmaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Turma", new { turmaUID = form.turmaUID, Area = "Comum" });
            }

            return Index();
        }
        public ActionResult MudarSituacao(long aulaUID)
        {
            long? turmaUID = null;
            try
            {
                var aula = idbucContext.Aulas.Find(aulaUID);

                turmaUID = aula.turmaUID;

                aula.ativa = !aula.ativa;

                idbucContext.SaveChanges();

                if (aula.ativa)
                {
                    AddMessage(UserMessageType.success, "A aula de " + aula.dataRealizacao.ToShortDateString() + " foi reciclada com sucesso!");
                }
                else
                {
                    AddMessage(UserMessageType.success, "A aula de " + aula.dataRealizacao.ToShortDateString() + " foi excluída com sucesso!");
                }
                
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (turmaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Turma", new { turmaUID = turmaUID, Area = "Comum" });
            }

            return Index();
        }
    }
}