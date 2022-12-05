using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IClient
{
    public interface IClientQuery
    {
        List<Cliente> GetClients();
        Cliente GetById(int id);

        bool ClientExist(string dni);
    }
}
