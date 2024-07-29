using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateUser
{
    public class CreateUserHandler:IRequestHandler<CreateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserHandler(IUsersRepository usersRepository, IValidator<CreateUserCommand> validator)
        {
            _usersRepository = usersRepository;
            _validator = validator;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var resultado = _validator.Validate(request);

            if (resultado.Errors.Count != 0)
                throw new Exception(resultado.Errors.First().ErrorMessage);

            var newuser = new Users { 
                firstName = request.firstName, 
                lastName = request.lastName,
                CUIT = request.CUIT ?? 999999999,
                rolId = request.rolId ?? 1,
            };
             await _usersRepository.Create(newuser);
        }
    }
}
