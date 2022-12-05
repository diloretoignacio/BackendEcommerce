using Aplication.Interfaces.IClient;
using Aplication.Interfaces.IOrden;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aplication.UseCase
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenCommand _command;
        private readonly IOrdenQuery _query;

        public OrdenService(IOrdenCommand command, IOrdenQuery query)
        {
            _command = command;
            _query = query;
        }

        public ResponseGral Create(int clientId)
        {
            if (!_query.ClientExist(clientId))
            {
                return new ResponseGral(404, new { Message = "El Cliente indicado NO existe" });
            }

            Carrito carrito = _query.CarritoAvaible(clientId);

            if (carrito == null)
            {
                return new ResponseGral(404, new { Message = "No existe un carrito activo para el usuario indicado" });
            }

            if(carrito.CarritoProductos.Count == 0)
            {
                return new ResponseGral(409, new { Message = "El carrito indicado se encuentra vacio" });
            }

            decimal total = 0;
            foreach(CarritoProducto carritoProducto in carrito.CarritoProductos)
            {
                total = total + (carritoProducto.Producto.Precio * carritoProducto.Cantidad);
            }

            var orden = new Orden
            {
                CarritoId = carrito.CarritoId,
                Fecha = DateTime.Now,
                Total = total
            };

            _command.Create(orden);
            _command.UpdateStatusCarrito(carrito);

            List<CarritoProductoResponse> carritoProductos = new List<CarritoProductoResponse>();
            foreach (CarritoProducto carritoProducto in orden.Carrito.CarritoProductos)
            {
                var producto = new ProductResponse
                {
                    ProductoId = carritoProducto.ProductoId,
                    Nombre = carritoProducto.Producto.Nombre,
                    Descripcion = carritoProducto.Producto.Descripcion,
                    Marca = carritoProducto.Producto.Marca,
                    Codigo = carritoProducto.Producto.Codigo,
                    Precio = carritoProducto.Producto.Precio,
                    Image = carritoProducto.Producto.Image
                };

                var carritoProductoResponse = new CarritoProductoResponse
                {
                    Cantidad = carritoProducto.Cantidad,
                    Producto = producto
                };
                carritoProductos.Add(carritoProductoResponse);
            }

            var response = new OrdenResponse
            {
                OrdenId = orden.OrdenId,
                Fecha = orden.Fecha,
                Total = orden.Total,
                Productos = carritoProductos
            };
            return new ResponseGral(201, response);
        }


        public ResponseGral GetReportDate(string from, string to)
        {
            try
            {
                DateTime fromDate = DateTime.Parse(from);
            }
            catch(Exception)
            {
                return new ResponseGral(409, new { Message = "El formato de la fecha From NO es correcto" });
            }

            try
            {
                DateTime toDate = DateTime.Parse(to);
            }
            catch (Exception)
            {
                return new ResponseGral(409, new { Message = "El formato de la fecha To NO es correcto" });
            }

            var ordenes = _query.GetReportDate(from, to);

            if (ordenes.Count == 0)
            {
                return new ResponseGral(404, new { Message = "NO existen ordenes en el periodo indicado" });
            }
            List<OrdenResponse> ordenesResponse = new List<OrdenResponse>();

            foreach (Orden orden in ordenes)
            {
                List<CarritoProductoResponse> carritoProductos = new List<CarritoProductoResponse>();
                int ClienteId = orden.Carrito.ClienteId;

                foreach (CarritoProducto carritoProducto in orden.Carrito.CarritoProductos)
                {
                    var producto = new ProductResponse
                    {
                        ProductoId = carritoProducto.ProductoId,
                        Nombre = carritoProducto.Producto.Nombre,
                        Descripcion = carritoProducto.Producto.Descripcion,
                        Marca = carritoProducto.Producto.Marca,
                        Codigo = carritoProducto.Producto.Codigo,
                        Precio = carritoProducto.Producto.Precio,
                        Image = carritoProducto.Producto.Image
                    };

                    var carritoProductoResponse = new CarritoProductoResponse
                    {
                        Cantidad = carritoProducto.Cantidad,
                        Producto = producto
                    };
                    carritoProductos.Add(carritoProductoResponse);
                }

                var resul = new OrdenResponse
                {
                    OrdenId = orden.OrdenId,
                    Fecha = orden.Fecha,
                    Total = orden.Total,
                    Productos = carritoProductos,
                    ClienteId = ClienteId
                };
                ordenesResponse.Add(resul);
            }

            decimal recaudacion = 0;
            foreach(OrdenResponse orden in ordenesResponse)
            {
                recaudacion = recaudacion + orden.Total;
            }

            var response = new OrdenReportResponse
            {
                from = from,
                to = to,
                recaudacion = recaudacion,
                orders = ordenesResponse
            };
            return new ResponseGral(200, response);
        }

    }
}
