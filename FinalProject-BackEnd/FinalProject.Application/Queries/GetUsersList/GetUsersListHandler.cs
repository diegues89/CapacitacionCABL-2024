using AutoMapper;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Interfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProject.Application.Queries.GetUsersList
{
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, GetUsersListResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetUsersListHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<GetUsersListResponse> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUsersListResponse();

            var userList = await _usersRepository.GetAll();

            response.UserList = userList
            .OrderByDescending(user => user.id)
            .Select(user => _mapper.Map<UsersDTO>(user))
            .ToList();
            return response;



        }
    }
}
