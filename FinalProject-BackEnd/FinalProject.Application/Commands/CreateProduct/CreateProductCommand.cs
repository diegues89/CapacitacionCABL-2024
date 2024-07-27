using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest
    {
       
        public string descriptionProduct { get; set; }
        public int stockQuantity { get; set; }
        public int idCategory { get; set; }
        public int idSupplier { get; set; }
    }
}
