using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models.Enumerators;
using UC.Models.ViewModels;
using UC.Utility;

namespace UC.Areas.Comum.Controllers
{
    public class ExecucaoMetaController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Index");
        }
        public ActionResult Execucao()
        {
            try
            {
                var registro = idbucContext.ExecucaoMetas.FirstOrDefault(x => x.ativo && x.Meta.ativo && x.situacao == (int)SituacaoPasso.Em_Andamento && x.Meta.usuarioUID == SimpleSessionPersister.usuarioUID);

                if (registro == null)
                {
                    throw new Exception("Nenhum passo está em execução.");
                }

                return RedirectToAction("Detalhes", new { execucaoMetaUID = registro.execucaoMetaUID});
            }
            catch(Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
        public ActionResult Detalhes(long execucaoMetaUID)
        {
            try
            {
                var registro = idbucContext.ExecucaoMetas.Find(execucaoMetaUID);

                if (registro == null)
                {
                    throw new Exception("Nenhum passo foi encontrado.");
                }

                var model = new VMExecucaoMeta(registro);

                return View(model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
                return Index();
            }
        }
    }
}