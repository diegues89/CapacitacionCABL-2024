using AutoMapper;
using FinalProject.Application.Commands.DeleteUser;
using FinalProject.Application.Queries.GetUser;
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
    public class GetUserHandlerTests
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly GetUserHandler _handler;

        public GetUserHandlerTests()
        {
            _userRepository = Substitute.For<IUsersRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetUserHandler(_userRepository, _mapper);
        }

        [Fact]
        public async Task GetUserHandler_ReturnEmpty_WhenUserNotExists()
        {
            // Arrange
            var userId = 42; // ID de usuario de ejemplo
            _userRepository.Get(Arg.Any<int>()).Returns((Users) null);
            // Act
            var request = new GetUserQuery { id = userId };
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.User);

        }
        [Fact]
        public async Task GetUserHandler_ReturnNotNull_WhenUserExists()
        {
            // Arrange
            var userId = 42;
            var existingUser = new Users { id = userId };
            var mappedUser = new UsersDTO();
            _userRepository.Get(userId).Returns(existingUser);
            _mapper.Map<UsersDTO>(existingUser).Returns(mappedUser);
            // Act
            var request = new GetUserQuery { id = userId };
            var response = await _handler.Handle(request, CancellationToken.None);
            // Assert
            Assert.NotNull(response.User);
            Assert.Same(mappedUser, response.User);
        }


    }
}
