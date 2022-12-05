using Aplication.Interfaces.ICarrito;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class CarritoCommand : ICarritoCommand
    {
        private readonly AppDbContext _context;

        public CarritoCommand(AppDbContext context)
        {
            _context = context;
        }

        public CarritoProducto AddProduct(AddCarritoRequest request, Carrito carrito)
        {
            CarritoProducto carritoProducto = new CarritoProducto
            {
                CarritoId = carrito.CarritoId,
                ProductoId = request.productId,
                Cantidad = request.amount
            };
            _context.CarritoProducto.Add(carritoProducto);
            _context.SaveChanges();
            return carritoProducto;
        }

        public Carrito Create(Carrito carrito)
        {
            _context.Add(carrito);
            _context.SaveChanges();
            return carrito;
        }

        public bool Delete(CarritoProducto carritoProducto)
        {
            _context.CarritoProducto.Remove(carritoProducto);
            _context.SaveChanges();
            return true;
        }

        public CarritoProducto Update(AddCarritoRequest request, CarritoProducto carritoProducto)
        {
            carritoProducto.Cantidad = request.amount;
            _context.SaveChanges();
            return carritoProducto;
        }
    }
}
