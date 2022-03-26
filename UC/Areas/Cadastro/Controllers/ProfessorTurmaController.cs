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
    public class ProfessorTurmaController : BaseController
    {
        const string Formulario = "FormularioProfessorTurma";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Novo()
        {
            try
            {
                var model = new VMFormProfessorTurma(myUnityOfHelpers);

                return View(Formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult IncluirProfessorNaTurma(long turmaUID)
        {
            try
            {
                var turma = idbucContext.Turmas.Find(turmaUID);

                if (turma == null)
                {
                    throw new Exception("A turma não foi encontrada.");
                }

                var model = new VMFormProfessorTurma(myUnityOfHelpers, turma);

                return View(Formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });
            }
        }

        public ActionResult GravarFormulario(VMFormProfessorTurma form)
        {
            try
            {
                if (!form.turmaUID.HasValue)
                {
                    throw new Exception("A turma não foi selecionada.");
                }

                if (!form.professorUID.HasValue)
                {
                    throw new Exception("O professor não foi escolhido.");
                }

                var novoProfessorTurma = new ProfessorTurma
                {
                    professorUID = form.professorUID.Value,
                    turmaUID = form.turmaUID.Value,
                    ativo = true,
                    dataCriacao = DateTime.Now,
                    professorturmaUID = 0,
                    validade = DateTime.Now.AddMonths(6)
                };

                idbucContext.ProfessorTurmas.Add(novoProfessorTurma);
                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Professor incluído com sucesso!");

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = novoProfessorTurma.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long professorTurmaUID)
        {
            try
            {
                var professorTurma = idbucContext.ProfessorTurmas.Find(professorTurmaUID);

                if (professorTurma == null)
                {
                    throw new Exception("Professor não encontrado.");
                }

                if (!professorTurma.ativo)
                {
                    throw new Exception("Este Professor já foi excluído.");
                }

                professorTurma.ativo = false;
                professorTurma.validade = DateTime.Now;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.info, "Este Professor foi excluído com sucesso.");

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = professorTurma.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}