using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VentaDominio;
using VentaServices.Models;
using VentaServices.Servicios.Factura;
using VentaServices.Servicios.FacturaDetalle;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaDetalleController : ControllerBase
    {
        private readonly IFacturaDetalleService _srvFacturaDetalle;
        private readonly IFacturaServices _srvFactura;

        public FacturaDetalleController(FacturacionContext context, IFacturaDetalleService facturaDetalleService, IFacturaServices srvFactura)
        {
            _srvFacturaDetalle = facturaDetalleService;
            _srvFactura = srvFactura;   
        }

        // GET: api/<FacturaDetalleController>
        [HttpGet]
        public IEnumerable<FacturaDetalle> Get(int idFactura)
        {
            return _srvFacturaDetalle.GetAllFacturaDetalle(idFactura);
        }        

        // POST api/<FacturaDetalleController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] FacturaDetalle facturaDetalle)
        {
            _srvFacturaDetalle.SaveFacturaDetalle(facturaDetalle);
            _srvFactura.UpdateFactura(facturaDetalle.IdFactura);
            return Ok("ok");

        }
        

        // DELETE api/<FacturaDetalleController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            _srvFacturaDetalle.DeleteFacturaDetalle (id);

            return Ok("ok");
        }
    }
}
