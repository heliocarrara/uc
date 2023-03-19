using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListMeta
    {
        public List<VMMeta> Metas { get; set; }

        public VMListMeta()
        {

        }

        public VMListMeta(IUnityOfHelpers u, List<Meta> metas)
        {
            this.Metas = new List<VMMeta>();

            foreach(var cadaMeta in metas)
            {
                this.Metas.Add(new VMMeta(u, cadaMeta));
            }
        }
    }
}