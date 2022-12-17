using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VentaDominio
{
    [Table("FacturaDetalles")]
    public class FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }

        public Factura FacturaFK { get; set; }

        [ForeignKey("FacturaFK")]

        public int IdFactura { get; set; }

        public Articulo ArticuloFK { get; set; }

        [ForeignKey("ArticuloFK")]
        public int IdArticulo { get; set; }

        

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioVenta { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Impuesto { get; set; }
    }
}
