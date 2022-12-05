using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities
{
    public class Orden
    {
        public Guid OrdenId { get; set; }
        public Guid CarritoId { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Total { get; set; }
        public Carrito Carrito { get; set; }
    }
}
