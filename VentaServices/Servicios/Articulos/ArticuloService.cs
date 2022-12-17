using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaDominio;
using VentaServices.Models;

namespace VentaServices.Servicios.Articulos
{
    public class ArticuloService:IArticuloService
    {

        private readonly FacturacionContext _context;

        public ArticuloService(FacturacionContext context)
        {
            _context = context;
        }
        public Articulo GetArticuloById(int id)
        {
            var articulo= _context.Articulos.Find(id);
            return articulo;
        }

        public IEnumerable<Articulo> GetListArticulo()
        {
            return _context.Articulos.ToList();
        }

        public Articulo SaveArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            _context.SaveChanges();
            return articulo;
        }

        public void UpdateArticulo(Articulo articulo)
        {
            var articuloEditar = _context.Articulos.Find(articulo.IdArticulo);

            articuloEditar.Descripcion = articulo.Descripcion;
            articuloEditar.Precio=articulo.Precio;  
            articuloEditar.Costo=articulo.Costo;
            articuloEditar.Activo= !articuloEditar.Activo?articulo.Activo:articuloEditar.Activo;            

            _context.Entry(articuloEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void InactivarArticulo(int idArticulo)
        {
            var articuloEditar = _context.Articulos.Find(idArticulo);
            
            articuloEditar.Activo = false;

            _context.Entry(articuloEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
