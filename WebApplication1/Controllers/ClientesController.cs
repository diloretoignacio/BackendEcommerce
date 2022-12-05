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
    public class ClientesController : ControllerBase
    {
        private readonly IClientService _services;

        public ClientesController(IClientService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var result = _services.GetClients();
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpPost]
        public IActionResult Create(ClientRequest request)
        {
            var result = _services.Create(request);
            return StatusCode(result.Codigo, result.Json);
        }

    }
}
