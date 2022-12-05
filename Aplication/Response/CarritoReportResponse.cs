using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class CarritoReportResponse
    {
        public Guid CarritoId { get; set; }
        public IList<CarritoProductoResponse> CarritoProductos { get; set; }
    }
}
