using Aplication.Response;
using Aplication.UseCase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Aplication.Mappers
{
    public class Mapper
    {
        public static ClienteResponse MapperCliente(Cliente cliente)
        {
            var response = new ClienteResponse
            {
                ClienteId = cliente.ClienteId,
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
                };
            return response;
        }

        public static ProductResponse MapperProduct (Producto product)
        {
            var response = new ProductResponse
            {
                ProductoId = product.ProductoId,
                Nombre = product.Nombre,
                Descripcion = product.Descripcion,
                Marca = product.Marca,
                Codigo = product.Codigo,
                Precio = product.Precio,
                Image = product.Image,
            };
            return response;
        }

        public static ClientResponse MapperClient(Cliente cliente)
        {
            ClientResponse response = new ClientResponse
            {
                ClienteId = cliente.ClienteId,
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono
            };
            return response;
        }

        public static CarritoResponse MapperCarrito(Carrito carrito)
        {
            List<CarritoProductoResponse> carritoProductos = new List<CarritoProductoResponse>();
            foreach(CarritoProducto carritoProducto in carrito.CarritoProductos)
            {
                carritoProductos.Add(MapperCarritoProducto(carritoProducto));
            }

            CarritoResponse response = new CarritoResponse
            {
                CarritoId = carrito.CarritoId,
                Estado = carrito.Estado,
                Cliente = MapperClient(carrito.Cliente),
                CarritoProductos = carritoProductos
            };
            return response;
        }

        public static CarritoProductoResponse MapperCarritoProducto(CarritoProducto carritoProducto)
        {
            ProductResponse productResponse = new ProductResponse
            {
                ProductoId = carritoProducto.Producto.ProductoId,
                Nombre = carritoProducto.Producto.Nombre,
                Descripcion = carritoProducto.Producto.Descripcion,
                Marca = carritoProducto.Producto.Marca,
                Codigo = carritoProducto.Producto.Codigo,
                Precio = carritoProducto.Producto.Precio,
                Image = carritoProducto.Producto.Image,
            };

            CarritoProductoResponse response = new CarritoProductoResponse
            {
                Cantidad = carritoProducto.Cantidad,
                Producto = productResponse
            };
            return response;
        }

    }
}
