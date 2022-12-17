using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaDominio ;
using VentaServices.Models;

namespace VentaServices.Servicios.Factura
{
    public class FacturaService:IFacturaServices
    {

        private readonly FacturacionContext _context;

        public FacturaService(FacturacionContext context)
        {
            _context = context;
        }
        public IEnumerable< VentaDominio.Factura> GetAllFactura()
        {
            return _context.Facturas.ToList();
        }

        public IEnumerable<VentaDominio.Factura> GetFacturaByCliente(string cliente)
        {
			//return _context.Facturas.Where(c=>c.Cliente.StartsWith  (cliente) || c.Cliente.EndsWith(cliente)) .ToList();
			return _context.Facturas.Where(c => c.Cliente.Contains(cliente)).ToList();
		}

        public IEnumerable<VentaDominio.Factura> GetFacturaByMonto(decimal montoMenor, decimal montoMayor)
        {
            return _context.Facturas.Where(c => c.Total>=montoMenor && c.Total<=montoMayor).ToList();
        }

        public VentaDominio.Factura SaveFactura(VentaDominio.Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges(); 
            return factura;
        }

        public void UpdateFactura(int facturaId)
        {
            var facturaEditar = _context.Facturas.Find(facturaId);

            facturaEditar.Subtotal = _context.FacturaDetalles
                .Where(f => f.IdFactura == facturaId)
                .Sum(f => f.SubTotal);

            facturaEditar.Impuesto = _context.FacturaDetalles
                .Where(f => f.IdFactura == facturaId)
                .Sum(f => f.Impuesto);

            facturaEditar.Total = facturaEditar.Subtotal + facturaEditar.Impuesto;

            _context.Entry(facturaEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;           
            _context.SaveChanges();            
        }

    }
    
}
