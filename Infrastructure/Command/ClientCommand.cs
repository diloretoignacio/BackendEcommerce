using Aplication.Interfaces;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interfaces.IClient;

namespace Infrastructure.Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly AppDbContext _context;

        public ClientCommand(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Cliente client)
        {
            _context.Add(client);
            _context.SaveChanges();
        }
    }
}
