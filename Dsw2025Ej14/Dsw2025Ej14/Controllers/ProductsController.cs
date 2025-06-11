using Dsw2025Ej14.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api.Controllers
{

    [ApiController]
    [Route("api/products")]

    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistencia;


        public ProductsController(IPersistencia persistencia)
        {
            _persistencia = persistencia;

        }
        [HttpGet]

        public IActionResult GetProducts()
        {
            var products = _persistencia.GetProducts();
            if (products?.Any() == false) return NoContent();
            return Ok(products);
        }

        [HttpGet("{sku}")]
        public IActionResult GetProductBySku(string sku)
        {
            var product = _persistencia.GetProduct(sku);
            if (product == null) return NotFound();


            return Ok(_persistencia.GetProduct(sku));
        }
    }

    [ApiController]
    [Route("health-check")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Check()
        {
            return Ok("Healthy");
        }
    }
}
