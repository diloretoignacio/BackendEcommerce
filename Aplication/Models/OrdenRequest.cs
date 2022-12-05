using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public interface OrdenRequest
    {
        public Guid CarritoId { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Total { get; set; }
        public Carrito Carrito { get; set; }
    }
}
