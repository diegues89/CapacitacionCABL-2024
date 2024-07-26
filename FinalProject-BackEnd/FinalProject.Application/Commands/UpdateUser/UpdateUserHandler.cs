using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateUser
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.Get(request.id);

            if (user is null)
                return;

            user.firstName = request.firstName;
            user.lastName = request.lastName;
            user.CUIT = request.CUIT;
            user.rolId = request.rolId;

            await _usersRepository.Update(user);
        }
    }
}
