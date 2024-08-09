using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand: IRequest
    {
        public int idCategory { get; set; }
        public string descriptionCategory { get; set; } = null!;
    }
}
