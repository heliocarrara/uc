﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Models.Enumerators;
using UC.Utility;

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

        public SelectList TiposDeMeta(int? tipo)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            foreach (TipoMeta val in Enum.GetValues(typeof(TipoMeta)))
            {
                aux.Add(new SelectListItem()
                {
                    Text = val.ToFriendlyString(),
                    Value = ((int)val).ToString()
                });
            }

            if (tipo.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", tipo.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        public SelectList SubTiposMeta(int? subTipoMetaUID)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            var subtipos = idbucContext.SubTipoMetas.Where(x => x.ativo).ToList();

            foreach (var cadaItem in subtipos)
            {
                aux.Add(new SelectListItem()
                {
                    Text = cadaItem.nome,
                    Value = cadaItem.subTipoMetaUID.ToString()
                });
            }

            if (subTipoMetaUID.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", subTipoMetaUID.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        public SelectList MetasPorUsuario(long? metaUID)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            var metas = idbucContext.Metas.Where(x => x.ativo && x.dataObjetivo >= DateTime.Today && x.usuarioUID == SimpleSessionPersister.usuarioUID).ToList();
            
            foreach (var cadaItem in metas)
            {
                aux.Add(new SelectListItem()
                {
                    Text = cadaItem.nome,
                    Value = cadaItem.metaUID.ToString()
                });
            }

            if (metaUID.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", metaUID.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        public SelectList TipoGatilhoHabito(int? tipo)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            //foreach (TipoGatilho val in Enum.GetValues(typeof(TipoGatilho)))
            //{
            //    aux.Add(new SelectListItem()
            //    {
            //        Text = val.ToFriendlyString(),
            //        Value = ((int)val).ToString()
            //    });
            //}

            aux.Add(new SelectListItem()
            {
                Text = TipoGatilho.Ciclo.ToFriendlyString(),
                Value = ((int)TipoGatilho.Ciclo).ToString()
            });

            if (tipo.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", tipo.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }

        public SelectList TipoCicloHabito(int? tipo)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            //foreach (TipoCiclo val in Enum.GetValues(typeof(TipoCiclo)))
            //{
            //    aux.Add(new SelectListItem()
            //    {
            //        Text = val.ToFriendlyString(),
            //        Value = ((int)val).ToString()
            //    });
            //}

            aux.Add(new SelectListItem()
            {
                Text = TipoCiclo.Diario.ToFriendlyString(),
                Value = ((int)TipoCiclo.Diario).ToString()
            });

            if (tipo.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", tipo.Value);
            }
            else
            {
                result = new SelectList(aux, "Value", "Text");
            }

            return result;
        }
        public SelectList ExecucaoDia(List<ExecucaoMeta> execucaoMetas, long? execucaoMetaUID)
        {
            SelectList result;

            var aux = new List<SelectListItem>();

            foreach (var val in execucaoMetas)
            {
                aux.Add(new SelectListItem()
                {
                    Text = $"{val.descricao} da meta {val.Meta.nome}",
                    Value = val.execucaoMetaUID.ToString()
                });
            }

            aux.Add(new SelectListItem()
            {
                Text = TipoCiclo.Diario.ToFriendlyString(),
                Value = ((int)TipoCiclo.Diario).ToString()
            });

            if (execucaoMetaUID.HasValue)
            {
                result = new SelectList(aux, "Value", "Text", execucaoMetaUID.Value);
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