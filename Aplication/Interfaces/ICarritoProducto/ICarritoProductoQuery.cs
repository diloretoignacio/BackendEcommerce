using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoQuery
    {
        List<CarritoProducto> GetAll();
    }
}
