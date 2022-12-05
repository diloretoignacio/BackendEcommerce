using Aplication.Interfaces;
using Aplication.Interfaces.IClient;
using Aplication.Models;
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
    public class ClientQuery : IClientQuery
    {
        private readonly AppDbContext _context;
        public ClientQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetClients()
        {
            var clients = _context.Cliente.ToList();
            return clients;
        }

        public Cliente GetById(int id)
        {
            var client = _context.Cliente.Include(t => t.Carritos).FirstOrDefault(t => t.ClienteId == id);
            return client;
        }

        public bool ClientExist(string dni)
        {
            var client = _context.Cliente.FirstOrDefault(t => t.DNI == dni);
            if(client == null)
            {
                return false;
            }
            return true;
        }

    }
}
