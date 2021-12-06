
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
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class AlunoController : BaseController
    {
        const string formulario = "FormularioAluno";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Novo()
        {
            try
            {
                var model = new VMFormAluno(myUnityOfHelpers);

                return View(formulario, model);
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult NovoDestaTurma(long turmaUID)
        {
            try
            {
                var model = new VMFormAluno(myUnityOfHelpers, turmaUID);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormAluno form)
        {
            try
            {
                if (!form.turmaUID.HasValue)
                {
                    throw new Exception("Erro ao buscar turma.");
                }

                var pessoa = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == form.cpf);

                if (pessoa == null)
                {
                    throw new Exception("Cadastro não encontrado.");
                }

                var temCadastro = idbucContext.Alunoes.FirstOrDefault(x => x.ativo && x.pessoaUID == pessoa.pessoaUID && x.turmaUID == form.turmaUID);

                if (temCadastro != null)
                {
                    throw new Exception(pessoa.nome + " já tem um cadastro feito no dia " + temCadastro.dataCriacao.ToShortDateString() + " para a turma de " + temCadastro.Turma.Modalidade.nome + " - " + temCadastro.Turma.HorarioInicio.ToShortTimeString());
                }

                if (!form.pessoaUID.HasValue || pessoa.pessoaUID != form.pessoaUID.Value)
                {
                    AddMessage(UserMessageType.info, "Foi encontrado um cadastro. Segue o nome em azul.");
                    return View(formulario, new VMFormAluno(myUnityOfHelpers, pessoa, form.turmaUID));
                }

                var novo = new UC.Models.Aluno
                {
                    alunoUID = 0,
                    turmaUID = form.turmaUID.Value,
                    pessoaUID = pessoa.pessoaUID,
                    dataCriacao = DateTime.Now,
                    ativo = true
                };

                idbucContext.Alunoes.Add(novo);

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Cadastro criado com sucesso.");

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = form.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long alunoUID)
        {
            try
            {
                var aluno = idbucContext.Alunoes.Find(alunoUID);

                if (aluno == null)
                {
                    throw new Exception("Aluno não encontrado");
                }

                aluno.ativo = false;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "Cadastro excluido com sucesso.");

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = aluno.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}