using FinalProject.Application.Commands.CreateProduct;
using FinalProject.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.descriptionProduct)
               .NotEmpty()
               .WithMessage("El nombre del producto no puede ser vacio.");
            RuleFor(x => x.stockQuantity)
               .NotEmpty()
               .WithMessage("El stock del producto no puede ser vacio.");
            RuleFor(x => x.stockQuantity)
               .GreaterThan(0)
               .WithMessage("El stock del producto no puede ser menor a cero");
        }

    }
}
