using Aplication.Interfaces.ICarrito;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class CarritoQuery : ICarritoQuery
    {
        private readonly AppDbContext _context;
        public CarritoQuery(AppDbContext context)
        {
            _context = context;
        }

        public Carrito CarritoAvaible(int clientId)
        {
            return _context.Carrito.Include(t => t.CarritoProductos).ThenInclude(t => t.Producto).FirstOrDefault(t => t.ClienteId == clientId && t.Estado == true);
        }

        public List<Carrito> GetAll()
        {
            var carritos = _context.Carrito.Include(t => t.Orden).ToList();
            return carritos;
        }

        public Carrito GetById(Guid id)
        {
            var carrito = _context.Carrito.Include(t => t.Orden).FirstOrDefault(t => t.CarritoId == id);
            return carrito;
        }

        public bool ClientExist(int id)
        {
            var client = _context.Cliente.FirstOrDefault(t => t.ClienteId == id);
            if(client == null)
            {
                return false;
            }
            return true;
        }

        public bool ProductExist(int id)
        {
            var product = _context.Producto.FirstOrDefault(t => t.ProductoId == id);
            if (product == null)
            {
                return false;
            }
            return true;
        }
    }
}
