using Bogus;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Application.Commands.DeleteUser;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BackEnd.Tests
{
    public class DeleteUserHandlerTests
    {
        private readonly IUsersRepository _userRepository;
       
        private readonly DeleteUserHandler _handler;

        public DeleteUserHandlerTests()
        {
            _userRepository = Substitute.For<IUsersRepository>();
           
            _handler = new DeleteUserHandler(_userRepository);
        }

        [Fact]
        public async Task DeleteUserHandler_ReturnError_WhenUserNotExists() 
        {
            // Arrange
            var command = new DeleteUserCommand();
            //Act
            _userRepository.Get(1).Returns((Users)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteUserHandler_ReturnOK_WhenUserExists()
        {

            // Arrange

            var userId = 1;
            var existingUser = new Users {  id = userId, firstName = "firstName", lastName = "lastName", CUIT = 13212, rolId = 1  }; // Crea un usuario de ejemplo
            
            var command = new DeleteUserCommand();
            
            _userRepository.Get(Arg.Any<int>()).Returns(existingUser);
            
            _userRepository.Delete(existingUser);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
