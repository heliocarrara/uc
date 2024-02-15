using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UC.Utility;

namespace UC.Models.UCEntityHelpers.Interfaces
{
    public interface IMetaHelper
    {
        bool PossoAlterar(Meta meta, out UserMessage message);
    }
}
