using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class CarritoResponseOrden
    {
        public Guid CarritoId { get; set; }
        public Boolean Estado { get; set; }
        public Cliente Cliente { get; set; }
        public IList<CarritoProductoResponse> CarritoProductos { get; set; }
    }
}
