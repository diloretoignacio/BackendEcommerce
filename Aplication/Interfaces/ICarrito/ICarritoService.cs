using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarrito
{
    public interface ICarritoService
    {
        ResponseGral CarritoAvaible(int clientId);
        ResponseGral AddProduct(AddCarritoRequest request);
        CarritoResponse Create(CarritoRequest request);
        ResponseGral Update(AddCarritoRequest request);
        ResponseGral Delete(int clientId, int productId);
    }
}
