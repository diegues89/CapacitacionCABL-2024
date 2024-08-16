using Bogus;
using FinalProject.Application.Commands.DeleteSupplier;
using FinalProject.Application.Commands.DeleteUser;
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
    public class DeleteSupplierHandlerTest
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly DeleteSupplierHandler _handler;

        public DeleteSupplierHandlerTest()
        {
            _suppliersRepository = Substitute.For<ISuppliersRepository>();
            _handler = new DeleteSupplierHandler(_suppliersRepository);
        }
        [Fact]
        public async Task DeleteSupplierHandler_ReturnError_WhenSupplierNotExists()
        {
            // Arrange
            var command = new DeleteSupplierCommand();
            //Act
            _suppliersRepository.Get(Arg.Any<int>()).Returns((Suppliers)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteSupplierHandler_ReturnOK_WhenSupplierExists()
        {

            // Arrange
            var existingSupplier = new Faker<Suppliers>()
                .RuleFor(s => s.idSupplier, f => f.Random.Int())
                .RuleFor(s => s.name, f => f.Name.Random.ToString())
                .RuleFor(s => s.CUIT, f => f.Random.Int())
                .RuleFor(s => s.address, f => f.Address.FullAddress())
                .RuleFor(s => s.phoneNumber, f => f.Phone.PhoneNumber())
                .Generate();
            var command = new DeleteSupplierCommand();

            _suppliersRepository.Get(Arg.Any<int>()).Returns(existingSupplier);

            _suppliersRepository.Delete(existingSupplier);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
