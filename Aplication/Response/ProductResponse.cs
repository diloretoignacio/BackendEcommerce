using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class ProductResponse
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Codigo { get; set; }
        public Decimal Precio { get; set; }
        public string Image { get; set; }
    }
}
