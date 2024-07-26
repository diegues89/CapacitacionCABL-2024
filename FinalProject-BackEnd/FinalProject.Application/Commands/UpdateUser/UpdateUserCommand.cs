using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int CUIT { get; set; }
        public int rolId { get; set; }
    }
}
