using Aplication.Interfaces.IOrden;
using Aplication.Models;
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
    public class OrdenCommand : IOrdenCommand
    {
        private readonly AppDbContext _context;

        public OrdenCommand(AppDbContext context)
        {
            _context = context;
        }

        public void UpdateStatusCarrito(Carrito carrito)
        {
            carrito.Estado = !carrito.Estado;
            _context.SaveChanges();
        }

        public void Create(Orden orden)
        {
            _context.Add(orden);
            _context.SaveChanges();
        }
    }
}
