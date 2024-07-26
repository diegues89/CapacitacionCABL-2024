using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
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

        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository; 
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
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
