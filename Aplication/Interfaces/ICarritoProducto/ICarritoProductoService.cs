using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoService
    {
        Task<CarritoProductoResponse> Create(CarritoProductoRequest request);
        CarritoProductoResponse Update(int id, CarritoProductoRequest request);
        Task<List<CarritoProductoResponse>> GetAll();
        CarritoProductoResponse GetById(int id);

        Task<bool> Delete(int id);
    }
}
