using Bogus;
using FinalProject.Application.Commands.CreateProduct;
using FinalProject.Application.Commands.CreateProductCategory;
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
    public class CreateProductHandlerTests
    {
        private readonly IProductsRepository _productsRepository;
        private readonly CreateProductHandler _handler;

        public CreateProductHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _handler = new CreateProductHandler(_productsRepository);
        }
        [Fact]
        public async Task CreateProductHandler_ReturnsNoError_WhenRequestIsValid()
        {
            //Arrange

            var command = new Faker<CreateProductCommand>()
                .RuleFor(x => x.descriptionProduct, f => f.Random.Word())
            .Generate();

            _productsRepository.Create(Arg.Any<products>()).Returns(1);
            //Act
            await _handler.Handle(command, CancellationToken.None);
            //Assert
        }
        [Fact]
        public async Task CreateProductHandler_ReturnsError_WhenRequestIsNotValid()
        {
            //Arrange
            var command = new CreateProductCommand();
            _productsRepository.Create(Arg.Any<products>()).Returns(-1);
            //Act

            //Assert
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
