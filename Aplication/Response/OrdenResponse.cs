using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class OrdenResponse
    {
        public Guid OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Total { get; set; }
        public List<CarritoProductoResponse> Productos { get; set; }
        public int ClienteId { get; set; }
    }
}
