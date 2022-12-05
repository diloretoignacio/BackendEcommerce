using Aplication.Interfaces.ICarritoProducto;
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
    public class CarritoProductoQuery : ICarritoProductoQuery
    {
        private readonly AppDbContext _context;
        public CarritoProductoQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<CarritoProducto> GetAll()
        {
            var carritoProductos = _context.CarritoProducto.Include(t => t.Carrito).ToList();
            return carritoProductos;
        }
    }
}
