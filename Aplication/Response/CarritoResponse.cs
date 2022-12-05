using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class CarritoResponse
    {
        public Guid CarritoId { get; set; }
        public Boolean Estado { get; set; }
        public ClientResponse Cliente { get; set; }
        public IList<CarritoProductoResponse> CarritoProductos { get; set; }
    }
}
