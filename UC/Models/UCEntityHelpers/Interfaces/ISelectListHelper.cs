﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface ISelectListHelper
    {
        SelectList TiposDeLogin(int? tipoLogin);
        SelectList DiasDaSemana(int? diaDaSemana);
        SelectList TiposDeMeta(int? tipo);
        SelectList SubTiposMeta(int? subTipoMetaUID);
        SelectList MetasPorUsuario(long? metaUID);
        SelectList TipoGatilhoHabito(int? tipo);
        SelectList TipoCicloHabito(int? tipo);
        SelectList ExecucaoDia(List<ExecucaoMeta> execucaoMetas, long? execucaoMetaUID);
    }
}
