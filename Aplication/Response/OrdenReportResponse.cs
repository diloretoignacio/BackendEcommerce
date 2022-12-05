using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class OrdenReportResponse
    {
        public string from { get; set; }
        public string to { get;set; }
        public decimal recaudacion { get;set; }
        public List<OrdenResponse> orders { get; set; }
    }
}
