using Bogus;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Application.Commands.DeleteUser;
using FinalProject.Application.Commands.UpdateUser;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BackEnd.Tests
{
    public class UpdateUserHandlerTests
    {
        private readonly IUsersRepository _userRepository;
        private readonly UpdateUserHandler _handler;

        public UpdateUserHandlerTests()
        {
            _userRepository = Substitute.For<IUsersRepository>();
            _handler = new UpdateUserHandler(_userRepository);
        }
        [Fact]
        public async Task UpdateUserHandler_ReturnError_WhenUserNotExists()
        {
            // Arrange
            var command = new UpdateUserCommand();
            //Act
            _userRepository.Get(Arg.Any<int>()).Returns((Users)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateUserHandler_ReturnOK_WhenUserExists()
        {

            // Arrange

            var userId = 1;
            
            var userFakeToUpdate = new Faker<Users>()
                .RuleFor(x => x.id, f => f.Random.Int())
                .RuleFor(x => x.firstName, f => f.Name.FirstName())
                .RuleFor(x => x.lastName, f => f.Name.LastName())
                .RuleFor(x => x.CUIT, f => f.Random.Int())
                .RuleFor(x => x.rolId, f => 1)
                .Generate();

            var command = new UpdateUserCommand();
            _userRepository.Get(Arg.Any<int>()).Returns(userFakeToUpdate);

            _userRepository.Update(userFakeToUpdate);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
