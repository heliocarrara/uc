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
        public SelectList TiposDeModalidade(int? tipoModalidade)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            foreach (TipoModalidade val in Enum.GetValues(typeof(TipoModalidade)))
            {
                aux.Add(new SelectListItem()
                {
                    Text = val.ToFriendlyString(),
                    Value = ((int)val).ToString()
                });
            }

            if (tipoModalidade.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", tipoModalidade.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

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

        public SelectList TurmasDisponiveis(long? turmaUID)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            var turmasDisponiveis = idbucContext.Turmas.Where(x => x.ativa && x.disponivel).ToList();

            foreach (var cadaTurma in turmasDisponiveis)
            {
                var nome = cadaTurma.Modalidade.nome + " - " + cadaTurma.HorarioInicio.ToShortTimeString();
                aux.Add(new SelectListItem()
                {
                    Text = nome,
                    Value = cadaTurma.turmaUID.ToString()
                });
            }

            if (turmaUID.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", turmaUID.Value);
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

        public SelectList ProfessoresDisponiveis(long? professorUID)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            var professoresDisponiveis = idbucContext.Professors.Where(x => x.ativo && x.validade > DateTime.Now).ToList();

            foreach (var cadaProfessor in professoresDisponiveis)
            {
                aux.Add(new SelectListItem()
                {
                    Text = cadaProfessor.Pessoa.nome,
                    Value = cadaProfessor.professorUID.ToString()
                });
            }

            if (professorUID.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", professorUID.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        //private SelectList WebConfigList(string ListName, int? selectedValue)
        //{
        //    try
        //    {
        //        SelectList result;
        //        var aux = new List<SelectListItem>();
        //        var section = (NameValueCollection)ConfigurationManager.GetSection(ListName);

        //        foreach (string key in section)
        //        { aux.Add(new SelectListItem() { Text = key, Value = section.Get(key) }); }

        //        if (selectedValue.HasValue)
        //        { result = new SelectList(aux, "Value", "Text", selectedValue.Value); }
        //        else
        //        { result = new SelectList(aux, "Value", "Text"); }

        //        return result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        #endregion
    }
}