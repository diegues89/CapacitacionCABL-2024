using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProductCategory
{
    public class GetProductCategoryQuery: IRequest<GetProductCategoryResponse>
    {
        public int idCategory { get; set; }
    }
}
