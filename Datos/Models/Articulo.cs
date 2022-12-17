using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Datos.Models
{
    [Table("Articulos")]
    internal class Articulo
    {


        [Column(TypeName = "int"),
         DatabaseGenerated(DatabaseGeneratedOption.Identity),
         Key]
        public short IdArticulo { get; set; }

        
        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public Boolean Activo { get; set; }
    }
}
