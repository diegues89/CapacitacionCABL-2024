using Azure;
using Bogus;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FluentValidation;
using NSubstitute;

namespace FinalProject_BackEnd.Tests
{
    public class CreateUserHandlerTests
    {
       private readonly CreateUserHandler _handler;
        private readonly IUsersRepository _userRepository;

        public CreateUserHandlerTests()
        {
            _userRepository = Substitute.For<IUsersRepository>();
            var validator = Substitute.For<IValidator<CreateUserCommand>>();

            _handler = new CreateUserHandler(_userRepository, validator);
        }
        [Fact]
        public async Task CreateUserHandler_ReturnsNoError_WhenRequestIsValid()
        {
            //Arrange
            //var command = new CreateUserCommand();
            //var command = new CreateUserCommand { firstName = "Diego" };
            var command = new Faker<CreateUserCommand>()
                .RuleFor(x => x.firstName, f => f.Name.FirstName())
                .Generate();

            _userRepository.Create(Arg.Any<Users>()).Returns(1);
            //Act
            await _handler.Handle(command, CancellationToken.None);
            //Assert
        }
        [Fact]
        public async Task CreateUserHandler_ReturnsError_WhenRequestIsNotValid()
        {
            //Arrange
            var command = new CreateUserCommand();
            _userRepository.Create(Arg.Any<Users>()).Returns(-1);
            //Act
            
            //Assert
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}