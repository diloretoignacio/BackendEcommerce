using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class CarritoProductoResponse
    {
        public int Cantidad { get; set; }
        public ProductResponse Producto { get; set; }
    }
}
