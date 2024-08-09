using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand: IRequest
    {
        public string descriptionCategory { get; set; }
    }
}
