using Aplication.Interfaces.IClient;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System.Xml.Linq;

namespace Aplication.UseCase
{
    public class ClientService : IClientService
    {
        private readonly IClientCommand _command;
        private readonly IClientQuery _query;

        public ClientService(IClientCommand command, IClientQuery query)
        {
            _command = command;
            _query = query;
        }

        public ResponseGral Create(ClientRequest request)
        {
            if (request.dni == "")
            {
                return new ResponseGral(409, new { Message = "El DNI es un campo obligatorio" });
            }

            if (request.name == "")
            {
                return new ResponseGral(409, new { Message = "El name es un campo obligatorio" });
            }

            if (request.lastName == "")
            {
                return new ResponseGral(409, new { Message = "El last name es un campo obligatorio" });
            }

            if (request.address == "")
            {
                return new ResponseGral(409, new { Message = "El address es un campo obligatorio" });
            }

            if (request.phoneNumber == "")
            {
                return new ResponseGral(409, new { Message = "El phone numer es un campo obligatorio" });
            }

            if (_query.ClientExist(request.dni))
            {
                return new ResponseGral(409, new { Message = "El cliente indicado ya existe" });
            }

            var client = new Cliente
            {
                DNI = request.dni,
                Nombre = request.name,
                Apellido = request.lastName,
                Direccion = request.address,
                Telefono = request.phoneNumber,
                Carritos = new List<Carrito>()
            };

            _command.Create(client);

            ClientResponse response = Mapper.MapperClient(client);
            return new ResponseGral(201, response);
        }

        public ResponseGral GetById(int id)
        {
            var client = _query.GetById(id);
            if(client == null)
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }

            ClientResponse response = Mapper.MapperClient(client);
            return new ResponseGral(200, response);
        }

        public ResponseGral GetClients()
        {
            var clients = _query.GetClients();
            if (clients.Count == 0)
            {
                return new ResponseGral(404, new { Message = "NO existen clientes registrados" });
            }

            List<ClientResponse> result = new List<ClientResponse>();
            foreach (Cliente cliente in clients)
            {
                var response = Mapper.MapperClient(cliente);
                result.Add(response);
            }
            return new ResponseGral(200, result);
        }

    }
}
