using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand :IRequest
    {
        public int idCategory { get; set; }
    }
}
