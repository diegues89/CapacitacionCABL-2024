using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetSupplier
{
    public class GetSupplierQuery: IRequest<GetSupplierResponse>
    {
        public int idSupplier { get; set; }
    }
}
