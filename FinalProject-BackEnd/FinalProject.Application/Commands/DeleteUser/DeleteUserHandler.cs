using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.DeleteUser
{

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository _usersRepository;

        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userdelete = await _usersRepository.Get(request.id);

            if (userdelete is null)
                return;

            await _usersRepository.Delete(userdelete);
        }
    }
}
