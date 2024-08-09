using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateSupplier
{
    public class CreateSupplierCommand: IRequest
    {
        public string name { get; set; }
        public int CUIT { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
