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
    public class ProfessorController : BaseController
    {
        const string formulario = "FormularioProfessor";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Novo()
        {
            try
            {
                var model = new VMFormProfessor();

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormProfessor form)
        {
            try
            {
                
                if (!form.pessoaUID.HasValue)
                {
                    if (String.IsNullOrWhiteSpace(form.cpf))
                    {
                        throw new Exception("Erro ao buscar cpf.");
                    }

                    var pessoa = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == form.cpf);

                    if (pessoa == null)
                    {
                        throw new Exception("Cadastro não encontrado.");
                    }

                    var novoModel = new VMFormProfessor(pessoa);

                    return View(formulario, novoModel);
                }

                if (form.professorUID.HasValue)
                {
                    throw new Exception("Não é possivel editar cadastro de professor.");
                }
                else
                {
                    var hoje = DateTime.Now;

                    if (idbucContext.Professors.Any(x => x.ativo && x.validade > hoje && x.pessoaUID == form.pessoaUID.Value))
                    {
                        throw new Exception("Esta pessoa já tem cadastro para ser professor. Tente outro CPF ou exclua o outro registro.");
                    }

                    var novoProfessor = new Models.Professor
                    {
                        professorUID = 0,
                        ativo = true,
                        pessoaUID = form.pessoaUID.Value,
                        validade = hoje.AddYears(1),
                        dataCriacao = hoje
                    };

                    idbucContext.Professors.Add(novoProfessor);

                    if (!idbucContext.Permissaos.Any(x => x.pessoaUID == form.pessoaUID.Value && x.validade > hoje && x.tipoLogin == (int)TipoLogin.Professor))
                    {
                        var permissao = new Permissao
                        {
                            permissaoUID = 0,
                            tipoLogin = (int)TipoLogin.Professor,
                            pessoaUID = form.pessoaUID.Value,
                            dataCriacao = DateTime.Now,
                            validade = hoje.AddYears(1)
                        };

                        idbucContext.Permissaos.Add(permissao);
                    }

                    idbucContext.SaveChanges();
                }

                AddMessage(UserMessageType.success, "Professor salvo com sucesso!");

                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long professorUID)
        {
            try
            {
                var professor = idbucContext.Professors.Find(professorUID);

                if (professor == null)
                {
                    throw new Exception("Professor não encontrado.");
                }

                if (!professor.ativo)
                {
                    throw new Exception("Este Professor foi excluído.");
                }

                professor.ativo = false;
                professor.validade = DateTime.Now;

                foreach (var cadaProfessor in professor.ProfessorTurmas.Where(x => x.ativo).ToList())
                {
                    cadaProfessor.ativo = false;
                    cadaProfessor.validade = DateTime.Now;
                }

                idbucContext.SaveChanges();

                var permissoes = idbucContext.Permissaos.Where(x => x.pessoaUID == professor.pessoaUID && x.validade > DateTime.Now && x.tipoLogin == (int)TipoLogin.Professor).ToList();

                if (permissoes != null && permissoes.Any())
                {
                    foreach (var cadaPermissao in permissoes)
                    {
                        cadaPermissao.validade = DateTime.Now;
                    }

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.info, "O perfil de Professor desta pessoa foi excluído.");
                }

                return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}