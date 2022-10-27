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
    public class SelectListHelper : BaseHelper, Interfaces.ISelectListHelper
    {
        #region CONSTRUCTORS

        public SelectListHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion
        #region METHODS

        public SelectList TiposDeLogin(int? tipoLogin) 
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            foreach (TipoLogin val in Enum.GetValues(typeof(TipoLogin)))
            {
                aux.Add(new SelectListItem()
                {
                    Text = val.ToFriendlyString(),
                    Value = ((int)val).ToString()
                });
            }

            if (tipoLogin.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", tipoLogin.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        
        public SelectList DiasDaSemana(int? diaDaSemana)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            foreach (DiaSemanal val in Enum.GetValues(typeof(DiaSemanal)))
            {
                aux.Add(new SelectListItem()
                {
                    Text = val.ToFriendlyString(),
                    Value = ((int)val).ToString()
                });
            }

            if (diaDaSemana.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", diaDaSemana.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        #endregion
    }
}