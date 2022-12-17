using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VentaDominio;

namespace VentaServices.Models
{
    public class FacturacionContext : DbContext
    {       

        public FacturacionContext(DbContextOptions<FacturacionContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=Factura;Integrated Security=True");
        }

    }
}
