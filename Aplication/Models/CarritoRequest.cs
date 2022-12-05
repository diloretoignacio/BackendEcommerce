using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CarritoRequest
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public Boolean Estado { get; set; }
    }
}
