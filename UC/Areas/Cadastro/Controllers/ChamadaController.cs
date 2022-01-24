using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UC.Controllers;
using UC.Models.ViewModels.ListViewModels;

namespace UC.Areas.Cadastro.Controllers
{
    [System.Web.Http.Authorize(Roles = "Coordenador, Secretario")]
    public class ChamadaController : BaseController
    {
        const string formularioChamada = "FormularioListaChamada";
        public ActionResult Index()
        {
            return RedirectToAction("Detalhes", "Painel", new { Area = Utility.SimpleSessionPersister.UserRole });
        }

        public ActionResult Nova(long aulaUID)
        {
            try
            {
                var aula = idbucContext.Aulas.Find(aulaUID);

                if (aula == null)
                {
                    throw new Exception("Esta aula não existe.");
                }

                if (aula.Chamadas != null && aula.Chamadas.Any(x => x.ativa))
                {
                    throw new Exception("Esta aula já tem a chamada registrada.");
                }

                var model = new VMListFormChamada(aula);

                return View(formularioChamada, model);
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID, Area = "Comum" });
        }

        public ActionResult GravarFormularioChamada(VMListFormChamada form)
        {
            try
            {
                var chamadas = new List<Models.Chamada>();

                for(int i = 0; i < form.chamadas.Count; i++)
                {
                    chamadas.Add(new Models.Chamada{
                        chamadaUID = 0,
                        aulaUID = form.aulaUID,
                        alunoUID = form.chamadas[i].alunoUID,
                        presente = form.chamadas[i].presenca,
                        ativa = true
                    });
                }

                idbucContext.Chamadas.AddRange(chamadas);

                idbucContext.SaveChanges();
                AddMessage(UserMessageType.success, "Lista de chamada foi salva com sucesso!");

                return RedirectToAction("Detalhes", "Aula", new { aulaUID = form.aulaUID, Area = "Comum" });
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            return RedirectToAction("Nova", "Aula", new { aulaUID = form.aulaUID, Area = "Cadastro" });
        }

        public ActionResult MudarSituacao(long chamadaUID)
        {
            long? aulaUID = null;
            try
            {
                var chamada = idbucContext.Chamadas.Find(chamadaUID);

                aulaUID = chamada.aulaUID;

                chamada.presente = !chamada.presente;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A chamada de foi alterada com sucesso!");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (aulaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID.Value, Area = "Comum" });
            }

            return Index();
        }

        public ActionResult Excluir(long chamadaUID)
        {
            long? aulaUID = null;
            try
            {
                var chamada = idbucContext.Chamadas.Find(chamadaUID);

                aulaUID = chamada.aulaUID;

                chamada.ativa = false;

                idbucContext.SaveChanges();

                AddMessage(UserMessageType.success, "A chamada foi alterada com sucesso!");
            }
            catch (Exception ex)
            {
                AddMessage(UserMessageType.error, ex);
            }

            if (aulaUID.HasValue)
            {
                return RedirectToAction("Detalhes", "Aula", new { aulaUID = aulaUID.Value, Area = "Comum" });
            }

            return Index();
        }
    }
}