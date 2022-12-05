using Aplication.Interfaces.ICarrito;
using Aplication.Interfaces.IClient;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoCommand _command;
        private readonly ICarritoQuery _query;

        public CarritoService(ICarritoCommand command, ICarritoQuery query)
        {
            _command = command;
            _query = query;
        }

        public ResponseGral CarritoAvaible(int clientId)
        {
            if (!_query.ClientExist(clientId))
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }
            
            Carrito carrito = _query.CarritoAvaible(clientId);

            if (carrito == null)
            {
                return new ResponseGral(404, new { Message = "NO existe un carrito para el usuario indicado" });
            }

            var response = Mapper.MapperCarrito(carrito);
            return new ResponseGral(200, response);
        }


        public ResponseGral AddProduct(AddCarritoRequest request)
        {
            if(!_query.ClientExist(request.clientId))
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }

            if(!_query.ProductExist(request.productId))
            {
                return new ResponseGral(404, new { Message = "El producto indicado NO existe" });
            }

            Carrito carrito = _query.CarritoAvaible(request.clientId);            

            if (carrito == null)
            {
                Carrito newCarrito = new Carrito
                {
                    ClienteId = request.clientId,
                    Estado = true
                };
                carrito = _command.Create(newCarrito);   
            }
            else
            {
                foreach (CarritoProducto carritoProducto in carrito.CarritoProductos)
                {
                    if(carritoProducto.ProductoId == request.productId)
                    {
                        return new ResponseGral(409,new { Message = "El producto ya se encuentra en el carrito" });
                    }
                }
            }
            _command.AddProduct(request, carrito);
            var response = new AddCarritoResponse
            {
                clientId = request.clientId,
                productId = request.productId,
                amount = request.amount
            };
            return new ResponseGral(201, response);
        }

        public CarritoResponse Create(CarritoRequest request)
        {
            var carrito = new Carrito
            {
                ClienteId = request.ClienteId,
                Estado = request.Estado
            };

            _command.Create(carrito);
            return Mapper.MapperCarrito(carrito);        
        }

        public ResponseGral Delete(int clientId, int productId)
        {
            if (!_query.ClientExist(clientId))
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }

            if (!_query.ProductExist(productId))
            {
                return new ResponseGral(404, new { Message = "El producto indicado NO existe" });
            }

            Carrito carrito = _query.CarritoAvaible(clientId);

            if (carrito == null)
            {
                return new ResponseGral(404, new { Message = "NO existe un carrito activo para el usuario indicado" });
            }

            foreach (CarritoProducto carritoProducto in carrito.CarritoProductos)
            {
                if (carritoProducto.ProductoId == productId)
                {
                    var response = _command.Delete(carritoProducto);
                    return new ResponseGral(200, new { Message = "El producto se ha eliminado correctamente del carrito" });
                }
            }
            return new ResponseGral(404, new { Message = "NO existe un carrito activo para los datos indicados" });
        }

       
        public ResponseGral Update(AddCarritoRequest request)
        {
            if (!_query.ClientExist(request.clientId))
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }

            if (!_query.ProductExist(request.productId))
            {
                return new ResponseGral(404, new { Message = "El producto indicado NO existe" });
            }

            Carrito carrito = _query.CarritoAvaible(request.clientId);

            if (carrito == null)
            {
                return new ResponseGral(404, new { Message = "NO existe un carrito activo para el usuario indicado" });
            }
            
            foreach (CarritoProducto carritoProducto in carrito.CarritoProductos)
            {
                if (carritoProducto.ProductoId == request.productId)
                {
                    _command.Update(request, carritoProducto);
                    var response = new AddCarritoResponse
                    {
                        clientId = request.clientId,
                        productId = request.productId,
                        amount = request.amount
                    };
                    return new ResponseGral(200, response);
                }
            }
            return new ResponseGral(404, new { Message = "NO existe el producto indicado en el carrito" }); ;
        }
    }
}
