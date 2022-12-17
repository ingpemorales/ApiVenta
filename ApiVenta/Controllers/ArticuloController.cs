using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using VentaDominio ;
using VentaServices.Models;
using VentaServices.Servicios.Articulos;
//using VentaServices.Models;
//using VentaDominio;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        private readonly IArticuloService _srvArticulo;

        public ArticuloController(FacturacionContext context, IArticuloService articuloService)
        {
            _srvArticulo = articuloService;
        }
       
        // GET: api/<ArticuloController>
        [HttpGet]
        public ActionResult< IEnumerable<Articulo>> Get()
        {

            var listaArticulos = _srvArticulo.GetListArticulo();

            return Ok(listaArticulos);
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public ActionResult<Articulo> Get(int id)
        {
            var art = _srvArticulo.GetArticuloById(id);

            return Ok(art);
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public ActionResult<Articulo> Post([FromBody] Articulo articulo)
        {
         return Ok( _srvArticulo.SaveArticulo(articulo));
        }

        // PUT api/<ArticuloController>/5
        [HttpPut]
        public ActionResult<string> Put( [FromBody] Articulo articulo)
        {

            _srvArticulo.UpdateArticulo(articulo);
            
            return Ok("ok");
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            _srvArticulo.InactivarArticulo (id);

            return Ok("ok");
        }
    }
}
