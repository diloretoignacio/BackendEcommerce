using Aplication.Interfaces.ICarrito;
using Aplication.Interfaces.IClient;
using Aplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _services;

        public CarritoController(ICarritoService services)
        {
            _services = services;
        }

 
        [HttpPost]
        public IActionResult AddProduct(AddCarritoRequest request)
        {
            var result = _services.AddProduct(request);
            return StatusCode(result.Codigo, result.Json);
        }


        [HttpPatch]
        public IActionResult Update(AddCarritoRequest request)
        {
            var result = _services.Update(request);
            return StatusCode(result.Codigo, result.Json);
        }


        [HttpDelete("{clientId}/{productId}")]
        public IActionResult Delete(int clientId, int productId)
        {
            var result = _services.Delete(clientId, productId);
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpGet("{clientId}")]
        public IActionResult CarritoAvaible(int clientId)
        {
            var result = _services.CarritoAvaible(clientId);
            return StatusCode(result.Codigo, result.Json);
        }
    }
}
