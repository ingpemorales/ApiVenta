using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaServices.Models;

namespace VentaServices.Servicios.FacturaDetalle
{
    public class FacturaDetalleService:IFacturaDetalleService
    {
        private readonly FacturacionContext _context;

        public FacturaDetalleService(FacturacionContext context)
        {
            _context = context;
        }
        public IEnumerable<VentaDominio.FacturaDetalle> GetAllFacturaDetalle(int facturaId)
        {
            return _context.FacturaDetalles.Where(d=>d.IdFactura==facturaId) .ToList();
        }

        public void SaveFacturaDetalle(VentaDominio.FacturaDetalle facturaDetalle)
        {
            var factura=_context.Facturas.Find(facturaDetalle.IdFactura); 
            
            facturaDetalle.SubTotal = facturaDetalle.Cantidad * facturaDetalle.PrecioVenta;
            facturaDetalle.Impuesto = (factura.PorcentajeImpuesto * facturaDetalle.SubTotal) / 100;


            _context.FacturaDetalles.Add(facturaDetalle);
            _context.SaveChanges();            
        }

        public void DeleteFacturaDetalle(int facturaDetalleId)
        {
            var detalle = _context.FacturaDetalles.Find(facturaDetalleId);

            _context.FacturaDetalles.Remove(detalle);
            _context.SaveChanges();
        }
    }
}
