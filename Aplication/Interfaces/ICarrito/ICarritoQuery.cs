using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarrito
{
    public interface ICarritoQuery
    {
        Carrito CarritoAvaible(int clientId);
        List<Carrito> GetAll();
        Carrito GetById(Guid id);

        bool ClientExist(int id);

        bool ProductExist(int id);
    }
}
