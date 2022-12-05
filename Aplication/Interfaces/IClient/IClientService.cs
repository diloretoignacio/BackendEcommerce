using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IClient
{
    public interface IClientService
    {
        ResponseGral GetClients();
        ResponseGral Create(ClientRequest request);
        ResponseGral GetById(int id);
    }
}
