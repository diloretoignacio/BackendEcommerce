using Aplication.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarrito
{
    public interface ICarritoCommand
    {
        CarritoProducto AddProduct(AddCarritoRequest request, Carrito carrito);
        Carrito Create(Carrito carrito);

        bool Delete(CarritoProducto carritoProducto);

        CarritoProducto Update(AddCarritoRequest request, CarritoProducto carritoProducto);
    }
}
