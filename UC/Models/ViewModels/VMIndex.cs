using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels
{
    public class VMIndex
    {
        public List<VMMeta> Metas { get; set; }

        public VMIndex()
        {

        }

        public VMIndex(List<Meta> metas)
        {
            this.Metas = new List<VMMeta>();

            foreach(var cadaMeta in metas)
            {
                this.Metas.Add(new VMMeta(cadaMeta));
            }
        }
    }
}