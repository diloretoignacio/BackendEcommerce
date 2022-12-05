using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IOrden
{
    public interface IOrdenService
    {
        ResponseGral Create(int clientId);
        ResponseGral GetReportDate(string from, string to);
    }
}
