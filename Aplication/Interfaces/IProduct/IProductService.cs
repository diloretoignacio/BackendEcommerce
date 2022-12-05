using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IProduct
{
    public interface IProductService
    {
        ResponseGral GetByName(string name, bool sort);
        ResponseGral GetById(int id);
    }
}
