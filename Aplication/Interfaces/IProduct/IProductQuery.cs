using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IProduct
{
    public interface IProductQuery
    {
        Producto GetById(int id);

        List<Producto> GetByName(string name, bool sort);
    }
}
