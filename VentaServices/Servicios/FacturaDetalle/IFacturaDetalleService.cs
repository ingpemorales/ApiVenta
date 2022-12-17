using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentaServices.Servicios.FacturaDetalle
{
    public interface IFacturaDetalleService
    {
        public IEnumerable<VentaDominio.FacturaDetalle> GetAllFacturaDetalle(int facturaId);

        public void SaveFacturaDetalle(VentaDominio.FacturaDetalle factura);

        public void DeleteFacturaDetalle(int facturaDetalleId);
            
    }
}
