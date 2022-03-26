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

        public string GetDiasDaSemana(Turma turma)
        {
            try
            {
                var dias = turma.DiaSemanaTurmas.Where(x => x.ativo).OrderBy(x => x.diaSemanal).ToList();
                var result = string.Empty;

                for (int i = 0; i < dias.Count; i++)
                {
                    if (dias.Count > 1)
                    {
                        if ((dias.Count - 1) == i)
                        {
                            result += " e ";
                            result += ((DiaSemanal)dias[i].diaSemanal).ToFriendlyString();
                        }
                        else
                        {
                            result += ((DiaSemanal)dias[i].diaSemanal).ToFriendlyString();
                            result += " , ";
                        }
                    }
                    else
                    {
                        result += ((DiaSemanal)dias[i].diaSemanal).ToFriendlyString();
                    }
                }

                return result;
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}