using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public int idProduct { get; set; }
        public string descriptionProduct { get; set; }
        public int stockQuantity { get; set; }
        public int idCategory { get; set; }
        public int idSupplier { get; set; }
    }
}
