using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace UC.Models.ViewModels.FormViewModels
{
    public class VMFormHabito
    {
        public Habito Habito { get; set;}

        public SelectList ListaTipoGatilho { get; set;}
        public SelectList ListaMetasDisponiveis { get; set;}


        public VMFormHabito()
        {

        }
        public VMFormHabito(IUnityOfHelpers u)
        {
            this.Habito = new Habito
            {
                habitoUID = 0,
                metaUID = 0
            };

            this.ListaMetasDisponiveis = u.SelectLists.MetasPorUsuario(null);
            this.ListaTipoGatilho = u.SelectLists.TipoGatilhoHabito(null);
        }
        public VMFormHabito(IUnityOfHelpers u, Meta meta)
        {
            this.Habito = new Habito
            {
                habitoUID = 0,
                metaUID = meta.metaUID,
                Meta = meta
            };

            this.ListaMetasDisponiveis = u.SelectLists.MetasPorUsuario(meta.metaUID);
            this.ListaTipoGatilho = u.SelectLists.TipoGatilhoHabito(null);
        }

        public VMFormHabito(IUnityOfHelpers u, Habito habito)
        {
            Habito = habito;

            this.ListaMetasDisponiveis = u.SelectLists.MetasPorUsuario(habito.metaUID);
            this.ListaTipoGatilho = u.SelectLists.TipoGatilhoHabito(habito.TipoGatilho);
        }
    }
}