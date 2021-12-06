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
    public class PermissaoController : BaseController
    {
        const string formulario = "FormularioPermissao";
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        public ActionResult Nova()
        {
            try
            {
                var model = new VMFormPermissao(myUnityOfHelpers);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Editar(long permissaoUID)
        {
            try
            {
                var permissao = idbucContext.Permissaos.Find(permissaoUID);

                var model = new VMFormPermissao(permissao, myUnityOfHelpers);

                return View(formulario, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Excluir(long permissaoUID)
        {
            try
            {
                var permissao = idbucContext.Permissaos.Find(permissaoUID);

                permissao.validade = DateTime.Now;

                AddMessage(UserMessageType.success, "A permissao de " + permissao.Pessoa.nome + " foi excluida com sucesso!");

                idbucContext.SaveChanges();

                return RedirectToAction("Lista", "Permissao", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult GravarFormulario(VMFormPermissao form)
        {
            try
            {
                if (form.permissaoUID > 0)
                {
                    var permissao = idbucContext.Permissaos.Find(form.permissaoUID);

                    permissao.pessoaUID = form.pessoaUID;
                    permissao.validade = form.validade;
                    permissao.tipoLogin = form.tipoLogin;

                    AddMessage(UserMessageType.success, "A permissao de " + permissao.Pessoa.nome + " foi alterada com sucesso!");

                    idbucContext.SaveChanges();
                }
                else
                {
                    var pessoa = idbucContext.Pessoas.FirstOrDefault(x => x.cpf == form.cpf);
                    var novaPermissao = new Permissao
                    {
                        permissaoUID = 0,
                        dataCriacao = DateTime.Now,
                        pessoaUID = pessoa.pessoaUID,
                        validade = DateTime.Now.AddDays(365),
                        tipoLogin = form.tipoLogin,
                };

                    idbucContext.Permissaos.Add(novaPermissao);

                    idbucContext.SaveChanges();
                    AddMessage(UserMessageType.success, "A permissao de " + novaPermissao.Pessoa.nome + " foi criada com sucesso!");
                }

                return RedirectToAction("Lista", "Permissao", new { Area = Utility.SimpleSessionPersister.UserRole });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}