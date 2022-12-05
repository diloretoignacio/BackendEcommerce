using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoCommand
    {
        Task Create(CarritoProducto client);

        bool Delete(int id);

        CarritoProducto Update(int id, CarritoProductoRequest request);
    }
}
