using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListUsuario
    {
        public List<Usuario> ListaUsuario { get; set; }

        public VMListUsuario()
        {
        }

        public VMListUsuario(List<Usuario> listaUsuario)
        {
            ListaUsuario = listaUsuario.OrderBy(x => x.usuarioUID).ToList();
        }
    }
}