using Aplication.Interfaces.IProduct;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class ProductQuery : IProductQuery
    {
        private readonly AppDbContext _context;
        public ProductQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> GetByName(string name, bool sort)
        {
            if (name == null) 
            {
                if (sort)
                {
                    return _context.Producto.OrderBy(y => y.Precio).ToList();
                }
                return _context.Producto.OrderByDescending(y => y.Precio).ToList();
            }
            
            if (sort)
            {
                return _context.Producto.OrderBy(y => y.Precio).Where(t => t.Nombre == name).ToList();
            }
            return _context.Producto.OrderByDescending(y => y.Precio).Where(t => t.Nombre == name).ToList();
        }

        public Producto GetById(int id)
        {
            var product = _context.Producto.FirstOrDefault(t => t.ProductoId == id);
            return product;
        }
    }
}
