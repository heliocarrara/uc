using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models.Enumerators;

namespace UC.Models.UCEntityHelpers
{
    public class TurmaHelper : BaseHelper, Interfaces.ITurmaHelper
    {
        #region CONSTRUCTORS

        public TurmaHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion
        #region METHODS
        public string GetNomeTurma(Turma turma)
        {
            try
            {
                return turma.Modalidade.nome + " - " + turma.HorarioInicio.ToShortTimeString();
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}