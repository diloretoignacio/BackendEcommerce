using Aplication.Interfaces.IOrden;
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
    public class OrdenQuery : IOrdenQuery
    {
        private readonly AppDbContext _context;
        public OrdenQuery(AppDbContext context)
        {
            _context = context;
        }

        public Carrito CarritoAvaible(int clientId)
        {
            return _context.Carrito.Include(t => t.CarritoProductos).ThenInclude(t => t.Producto).FirstOrDefault(t => t.ClienteId == clientId && t.Estado == true);
        }

        public List<Orden> GetReportDate(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);

            var ordenes = _context.Orden.Include(t => t.Carrito).ThenInclude(t => t.CarritoProductos).ThenInclude(t => t.Producto).Where(t => t.Fecha.Date >= fromDate.Date && t.Fecha.Date <= toDate.Date).ToList();
            return ordenes;
        }

        public bool ClientExist(int clientId)
        {
            var client = _context.Cliente.FirstOrDefault(t => t.ClienteId == clientId);
            if(client == null)
            {
                return false;
            }
            return true;
        }

    }
}
