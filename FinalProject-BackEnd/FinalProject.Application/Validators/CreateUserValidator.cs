using FinalProject.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.firstName)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage("No puede tener una longitud menor a 4");
        }
    }
}
