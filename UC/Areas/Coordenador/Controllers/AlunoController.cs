using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class AlunoController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Lista(long turmaUID)
        {
            try
            {
                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = turmaUID });

                //var lista = new List<VMAluno>();

                //var alunos = idbucContext.Alunoes.Where(x => x.ativo).ToList();

                //foreach (var cadaAluno in alunos)
                //{
                //    var turmas = idbucContext.Turmas.Where(x => x.ativa && x.disponivel && x.modalidadeUID == cadaModalidade.modalidadeUID).ToList();

                //    lista.Add(new VMAluno(cadaModalidade, turmas));
                //}

                //var model = new VMAluno(lista);

                //ViewBag.Message = "Alunos";

                //return View("ListaAluno", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }

            //CRIAR VIEW LISTAALUNO
            //CRIAR VMALUNO
            //CRIAR ESTA LISTA NO COMUM E PARA SECRETARIO
        }
    }
}