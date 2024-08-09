using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductResponse>
    {
        public int idProduct { get; set; }
    }
}
