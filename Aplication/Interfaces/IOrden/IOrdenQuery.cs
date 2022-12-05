using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IOrden
{
    public interface IOrdenQuery
    {
        public Carrito CarritoAvaible(int clientId);
        List<Orden> GetReportDate(string from, string to);

        bool ClientExist(int id);
    }
}
