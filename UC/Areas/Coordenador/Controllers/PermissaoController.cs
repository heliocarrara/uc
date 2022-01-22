using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.ViewModels;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Coordenador.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador")]
    public class PermissaoController : BaseController
    {
        const string viewLista = "ListaPermissao";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel");
        }

        public ActionResult Lista()
        {
            try
            {
                var lista = new List<VMPermissao>();

                var permissao = idbucContext.Permissaos.Where(x => x.validade > DateTime.Now).ToList();

                foreach (var cadaPermissao in permissao)
                {
                    lista.Add(new VMPermissao(cadaPermissao, myUnityOfHelpers));
                }

                lista = lista.OrderBy(x => x.pessoa.nome).ToList();

                var model = new VMListPermissao(lista);

                ViewBag.Message = "Permissões";

                return View(viewLista, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult ListaPorPessoa(long pessoaUID)
        {
            try
            {
                var model = new List<VMPermissao>();

                var permissoes = idbucContext.Permissaos.Where(x => x.pessoaUID == pessoaUID).ToList();

                foreach (var cadaPermissao in permissoes)
                {
                    model.Add(new VMPermissao(cadaPermissao, myUnityOfHelpers));
                }

                ViewBag.Message = "Permissões";

                return View(viewLista, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        //public ActionResult Lixeira()
        //{
        //    try
        //    {
        //        var turma = idbucContext.Turmas.Where(x => x.ativa == false || x.disponivel == false).ToList();

        //        var model = new VMListTurma(turma);

        //        ViewBag.Message = "Turmas desativadas";

        //        return View("ListaTurma", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        AddMessage(UserMessageType.error, ex);
        //        return Index();
        //    }
        //}
    }
}