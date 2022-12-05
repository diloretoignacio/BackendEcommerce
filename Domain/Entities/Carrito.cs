using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public Boolean Estado { get; set; }

        public Cliente Cliente { get; set; }
        public IList<CarritoProducto> CarritoProductos { get; set; }
        public Orden Orden { get; set; }
    }
}
