using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentaServices.Servicios.Factura
{
    public interface IFacturaServices
    {
        public IEnumerable<VentaDominio.Factura> GetAllFactura();

        public IEnumerable<VentaDominio.Factura> GetFacturaByCliente(string cliente);

        public IEnumerable<VentaDominio.Factura> GetFacturaByMonto(decimal montoMenor, decimal montoMayor);

        public VentaDominio.Factura SaveFactura(VentaDominio.Factura factura);

        public void UpdateFactura(int facturaId);
    }
}
