using Bogus;
using FinalProject.Application.Commands.UpdateProduct;
using FinalProject.Application.Commands.UpdateProductCategory;
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
    public class UpdateProductHandlerTests
    {
        private readonly IProductsRepository _productsRepository;
        private readonly UpdateProductHandler _handler;

        public UpdateProductHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _handler = new UpdateProductHandler(_productsRepository);
        }
        [Fact]
        public async Task UpdateProductHandler_ReturnError_WhenProductNotExists()
        {
            // Arrange
            var command = new UpdateProductCommand();
            //Act
            _productsRepository.Get(Arg.Any<int>()).Returns((products)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateProductHandler_ReturnOK_WhenProductExists()
        {

            // Arrange

            var ProductFakeToUpdate = new Faker<products>()
                .RuleFor(x => x.idProduct, f => f.Random.Int())
                .RuleFor(x => x.descriptionProduct, f => f.Random.Word())
                .Generate();

            var command = new UpdateProductCommand();
            _productsRepository.Get(Arg.Any<int>()).Returns(ProductFakeToUpdate);

            _productsRepository.Update(ProductFakeToUpdate);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
