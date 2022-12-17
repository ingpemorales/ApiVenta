using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VentaDominio
{
    [Table("Articulos")]
    public class Articulo
    {

        [Key]
        public int IdArticulo { get; set; }


        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Costo { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        public Boolean Activo { get; set; }

    }
}
