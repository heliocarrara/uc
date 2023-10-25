using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;
using UC.Models.Enumerators;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class AtividadeFixaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }
        public ActionResult Detalhes(long atividadeFixaUID)
        {
            try
            {
                var atividade = idbucContext.AtividadeFixas.Find(atividadeFixaUID);

                if (true ||  atividade == null || !atividade.ativa)
                {
                    throw new Exception("Erro ao carregar atividade");
                }

                return View(atividade);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }

        public ActionResult Lista()
        {
            try
            {
                var metas = idbucContext.Metas.Where(x => x.ativo && x.usuarioUID == SimpleSessionPersister.usuarioUID && x.dataObjetivo >= DateTime.Today).ToList();

                var atividades = new List<AtividadeFixa>();

                foreach (var cadaMeta in metas)
                {
                    var listaAtividade = cadaMeta.AtividadeFixas.Where(x => x.ativa).ToList();
                    atividades.AddRange(listaAtividade);
                }

                var model = new VMFormBuscaAtividadeFixa(myUnityOfHelpers, atividades);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult FiltrarResultados(long metaUID)
        {
            try
            {
                var meta = idbucContext.Metas.Find(metaUID);

                var atividades = meta.AtividadeFixas.Where(x => x.ativa).ToList();

                var model = new VMFormBuscaAtividadeFixa(myUnityOfHelpers, atividades);

                return View("Lista", model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}