using System;
using System.Collections.Generic;
using System.Text;

namespace VentaDominio
{
    public class FacturaViewModel
    {
        public Factura factura { get; set; }
        public List<FacturaDetalle> facturaDetalle { get; set; }
    }
}
