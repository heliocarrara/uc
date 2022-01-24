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
        /*const string Formulario = "FormularioBolsista";
        public ActionResult Index()
        {
            return RedirectToAction("Lista", "Bolsista", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Novo()
        {
            try
            {
                var model = new VMFormBolsista(myUnityOfHelpers);

                return View(Formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormBolsista form)
        {
            try
            {
                if (!form.turmaUID.HasValue)
                {
                    throw new Exception("Erro ao buscar turma.");
                }

                if (String.IsNullOrWhiteSpace(form.cpf))
                {
                    throw new Exception("Erro ao buscar cpf.");
                }

                if (!form.pessoaUID.HasValue)
                {
                    var pessoa = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == form.cpf);

                    if (pessoa == null)
                    {
                        throw new Exception("Cadastro não encontrado.");
                    }

                    var novoModel = new VMFormBolsista(myUnityOfHelpers, pessoa, form.turmaUID);

                    return View(Formulario, novoModel);
                }

                if (form.bolsistaUID.HasValue)
                {
                    var b = idbucContext.Bolsistas.Find(form.bolsistaUID.Value);

                    b.turmaUID = form.turmaUID.Value != b.turmaUID ? form.turmaUID.Value: throw new Exception("As turmas são iguais.");

                    idbucContext.SaveChanges();
                }
                else
                {
                    var hoje = DateTime.Now;

                    if (idbucContext.Bolsistas.Any(x => x.ativo && x.validade > hoje && x.pessoaUID == form.pessoaUID.Value && x.turmaUID == form.turmaUID.Value))
                    {
                        throw new Exception("Esta pessoa já tem cadastro para esta turma. Tente outro CPF ou exclua o outro registro.");
                    }

                    var novo = new UC.Models.Bolsista
                    {
                        bolsistaUID = 0,
                        ativo = true,
                        pessoaUID = form.pessoaUID.Value,
                        turmaUID = form.turmaUID.Value,
                        dataCriacao = DateTime.Now,
                        validade = DateTime.Now.AddMonths(6)
                    };

                    idbucContext.Bolsistas.Add(novo);
                    idbucContext.SaveChanges();

                    var novoProfessor = new Professor
                    {
                        professorUID = 0,
                        ativo = true,
                        bolsistaUID = novo.bolsistaUID,
                        validade = novo.validade
                    };

                    idbucContext.Professors.Add(novoProfessor);
                    idbucContext.SaveChanges();

                    var novoProfessorTurma = new ProfessorTurma
                    {
                        professorturmaUID = 0,
                        ativo = true,
                        professorUID = novoProfessor.professorUID,
                        turmaUID = form.turmaUID.Value
                    };

                    idbucContext.ProfessorTurmas.Add(novoProfessorTurma);

                    if (!idbucContext.Permissaos.Any(x => x.pessoaUID == form.pessoaUID.Value && x.validade > hoje && x.tipoLogin == (int)TipoLogin.Bolsista))
                    {
                        var permissao = new Permissao
                        {
                            permissaoUID = 0,
                            tipoLogin = (int)TipoLogin.Bolsista,
                            pessoaUID = form.pessoaUID.Value,
                            dataCriacao = DateTime.Now,
                            validade = novo.validade
                        };

                        idbucContext.Permissaos.Add(permissao);
                    }
                    idbucContext.SaveChanges();
                }

                AddMessage(UserMessageType.success, "Bolsista salvo com sucesso!");

                return RedirectToAction("Lista", "Bolsista", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Editar(long bolsistaUID)
        {
            try
            {
                var bolsista = idbucContext.Bolsistas.Find(bolsistaUID);

                if (bolsista == null)
                {
                    throw new Exception("Bolsista não encontrado.");
                }

                if (!bolsista.ativo)
                {
                    throw new Exception("Este bolsista foi excluído.");
                }

                var model = new VMFormBolsista(bolsista, myUnityOfHelpers);

                return View(Formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long bolsistaUID)
        {
            try
            {
                var bolsista = idbucContext.Bolsistas.Find(bolsistaUID);

                if (bolsista == null)
                {
                    throw new Exception("Bolsista não encontrado.");
                }

                if (!bolsista.ativo)
                {
                    throw new Exception("Este bolsista foi excluído.");
                }

                bolsista.ativo = false;
                bolsista.validade = DateTime.Now;

                if (bolsista.Professors != null && bolsista.Professors.Any(x => x.ativo))
                {
                    foreach (var cadaProfessor in bolsista.Professors.Where(x => x.ativo).ToList())
                    {
                        cadaProfessor.ativo = false;
                        cadaProfessor.validade = DateTime.Now;

                        if (cadaProfessor.ProfessorTurmas != null && cadaProfessor.ProfessorTurmas.Any(x => x.ativo))
                        {
                            foreach (var cadaProfessorTurma in cadaProfessor.ProfessorTurmas.Where(x => x.ativo).ToList())
                            {
                                cadaProfessorTurma.ativo = false;
                            }
                        }
                    }
                }

                idbucContext.SaveChanges();

                var permissoes = idbucContext.Permissaos.Where(x => x.pessoaUID == bolsista.pessoaUID && x.validade > DateTime.Now && x.tipoLogin == (int)TipoLogin.Bolsista).ToList();

                if (permissoes != null && permissoes.Any())
                {
                    foreach (var cadaPermissao in permissoes)
                    {
                        cadaPermissao.validade = DateTime.Now;
                    }

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.info, "O perfil de Bolsista desta pessoa foi excluído.");
                }

                return RedirectToAction("Detalhes", "Turma", new { Area = "Comum", turmaUID = bolsista.turmaUID });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }*/
    }
}