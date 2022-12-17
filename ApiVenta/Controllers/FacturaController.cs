using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VentaDominio;
using VentaServices.Models;
using VentaServices.Servicios.Articulos;
using VentaServices.Servicios.Factura;
using VentaServices.Servicios.FacturaDetalle;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private readonly IFacturaServices _srvFactura;
        private readonly IFacturaDetalleService _srvFacturaDetalle;

        public FacturaController(FacturacionContext context, IFacturaServices facturaService, IFacturaDetalleService facturaDetalleService)
        {
            _srvFactura = facturaService;
            _srvFacturaDetalle= facturaDetalleService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            return _srvFactura.GetAllFactura();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{montomenor}/{montomayor}")]
        public IEnumerable<Factura> Get(decimal montoMenor, decimal montoMayor)
        {
            return _srvFactura.GetFacturaByMonto(montoMenor, montoMayor);
        }

        // GET api/<FacturaController>/5
        [HttpGet("{nombrecliente}")]
        public IEnumerable<Factura> Get(string nombreCliente)
        {
            return _srvFactura.GetFacturaByCliente(nombreCliente);
        }

        // POST api/<FacturaController>
        [HttpPost]
        public ActionResult<Factura> Post([FromBody] FacturaViewModel facturaVM)
        {
            facturaVM.factura.Fecha = System.DateTime.Now;

            facturaVM.factura.Impuesto = facturaVM.facturaDetalle.Sum(x => x.Impuesto);
			facturaVM.factura.Subtotal = facturaVM.facturaDetalle.Sum(x => x.SubTotal);
            facturaVM.factura.Total = facturaVM.factura.Impuesto + facturaVM.factura.Subtotal;

			var newFactura= _srvFactura.SaveFactura(facturaVM.factura);

            foreach (var item in facturaVM.facturaDetalle)
            {
                item.IdFactura=newFactura.IdFactura;
                _srvFacturaDetalle.SaveFacturaDetalle(item);
            }

            return newFactura;
        }        

    }
}
