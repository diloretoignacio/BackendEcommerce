using Aplication.Interfaces.IClient;
using Aplication.Interfaces.IOrden;
using Aplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenService _services;

        public OrdenController(IOrdenService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetReportDate(string from, string to)
        {
            var result = _services.GetReportDate(from, to);
            return StatusCode(result.Codigo, result.Json);
        }


        [HttpPost("{clientId}")]
        public IActionResult Create(int clientId)
        {
            var result = _services.Create(clientId);
            return StatusCode(result.Codigo, result.Json);
        }

    }
}
