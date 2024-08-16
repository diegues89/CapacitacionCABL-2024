using AutoMapper;
using FinalProject.Application.Queries.GetUser;
using FinalProject.Application.Queries.GetUsersList;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BackEnd.Tests
{
    public class GetUsersListHandlerTest
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly GetUsersListHandler _handler;

        public GetUsersListHandlerTest()
        {
            _userRepository = Substitute.For<IUsersRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetUsersListHandler(_userRepository, _mapper);
        }

        [Fact]
        public async Task GetUsersListHandler_ReturnsMappedUserList_WhenUsersExists()
        {
            // Arrange
            var userListFromRepository = new List<Users>
            {
            new Users { id = 1, firstName = "Alice" },
            new Users { id = 2, firstName = "Bob" }

            };

            var mappedUserList = new List<UsersDTO>
            {
                new UsersDTO { id = 1, firstName = "AliceDTO" },
                new UsersDTO { id = 2, firstName = "BobDTO" }
            };

            _userRepository.GetAll().Returns(userListFromRepository);
            _mapper.Map<UsersDTO>(Arg.Any<Users>()).Returns(callInfo =>
            {
                var user = callInfo.ArgAt<Users>(0);
                return mappedUserList.FirstOrDefault(u => u.id == user.id);
            });
            // Act
            var request = new GetUsersListQuery();
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.UserList);
            

        }
       

    }
}
