using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VentaDominio;

namespace VentaServices.Servicios.Articulos
{
    public interface IArticuloService
    {
        public Articulo GetArticuloById(int id);

        public IEnumerable<Articulo> GetListArticulo();
        public Articulo SaveArticulo(Articulo articulo);
        public void UpdateArticulo(Articulo articulo);

        public void InactivarArticulo(int idArticulo);
    }
}
