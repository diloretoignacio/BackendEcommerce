using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CarritoProductoRequest
    {
        public int CarritoId { get; set; } 
        public int productId { get; set; }
        public int amount { get; set; }
    }
}
