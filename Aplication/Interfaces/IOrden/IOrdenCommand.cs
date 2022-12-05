using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IOrden
{
    public interface IOrdenCommand
    {
        void Create(Orden orden);

        void UpdateStatusCarrito(Carrito carrito);
    }
}
