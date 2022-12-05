using Aplication.Interfaces;
using Aplication.Interfaces.IProduct;
using Aplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductService _services;

        public ProductosController(IProductService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetProducsByName(string? name, bool sort = false)
        {
            var result = _services.GetByName(name,sort);
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var result = _services.GetById(id);
            return StatusCode(result.Codigo, result.Json);
        }

    }
}
