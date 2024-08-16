using Bogus;
using FinalProject.Application.Commands.UpdateSupplier;
using FinalProject.Application.Commands.UpdateUser;
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
    public class UpdateSupplierHandlerTests
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly UpdateSupplierHandler _handler;

        public UpdateSupplierHandlerTests()
        {
            _suppliersRepository = Substitute.For<ISuppliersRepository>();
            _handler = new UpdateSupplierHandler(_suppliersRepository);
        }
        [Fact]
        public async Task UpdateSupplierHandler_ReturnError_WhenSupplierNotExists()
        {
            // Arrange
            var command = new UpdateSupplierCommand();
            //Act
            _suppliersRepository.Get(Arg.Any<int>()).Returns((Suppliers)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateSupplierHandler_ReturnOK_WhenSupplierExists()
        {

            // Arrange

            var SuppierFakeToUpdate = new Faker<Suppliers>()
                .RuleFor(x => x.idSupplier, f => f.Random.Int())
                .RuleFor(x => x.name, f => f.Name.FirstName())
                .Generate();

            var command = new UpdateSupplierCommand();
            _suppliersRepository.Get(Arg.Any<int>()).Returns(SuppierFakeToUpdate);

            _suppliersRepository.Update(SuppierFakeToUpdate);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }


    }
}
