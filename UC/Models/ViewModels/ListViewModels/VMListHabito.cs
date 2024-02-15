using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UC.Models.ViewModels.ListViewModels
{
    public  class VMListHabito
    {
        public List<Habito> Habitos { get; set; }

        public long? metaUID { get; set; }

        public VMListHabito(List<Habito> habitos)
        {
            Habitos = habitos;
        }

        public VMListHabito(Meta meta) : this(meta.Habitos.Where(x => x.ativo).ToList())
        {
            this.metaUID = meta.metaUID;
        }
    }
}