using Bogus;
using FinalProject.Application.Commands.CreateSupplier;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BackEnd.Tests
{
    public class CreateSupplierHandlerTest
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly CreateSupplierHandler _handler;

        public CreateSupplierHandlerTest()
        {
            _suppliersRepository = Substitute.For<ISuppliersRepository>();
            _handler = new CreateSupplierHandler(_suppliersRepository);
        }
        [Fact]
        public async Task CreateSupplierHandler_ReturnsNoError_WhenRequestIsValid()
        {
            //Arrange
            
            var command = new Faker<CreateSupplierCommand>()
                .RuleFor(x => x.name, f => f.Name.FirstName())
            .Generate();

            _suppliersRepository.Create(Arg.Any<Suppliers>()).Returns(1);
            //Act
            await _handler.Handle(command, CancellationToken.None);
            //Assert
        }
        [Fact]
        public async Task CreateSupplierHandler_ReturnsError_WhenRequestIsNotValid()
        {
            //Arrange
            var command = new CreateSupplierCommand();
            _suppliersRepository.Create(Arg.Any<Suppliers>()).Returns(-1);
            //Act

            //Assert
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
