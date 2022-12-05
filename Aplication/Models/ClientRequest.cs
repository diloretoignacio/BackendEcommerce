using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class ClientRequest
    {
        public string dni { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
