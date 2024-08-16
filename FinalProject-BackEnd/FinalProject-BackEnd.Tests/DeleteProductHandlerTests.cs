using Bogus;
using FinalProject.Application.Commands.DeleteProduct;
using FinalProject.Application.Commands.DeleteSupplier;
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
    public class DeleteProductHandlerTests
    {
        private readonly IProductsRepository _productsRepository;
        private readonly DeleteProductHandler _handler;

        public DeleteProductHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _handler = new DeleteProductHandler(_productsRepository);
        }
        [Fact]
        public async Task DeleteProductHandler_ReturnError_WhenProductNotExists()
        {
            // Arrange
            var command = new DeleteProductCommand();
            //Act
            _productsRepository.Get(Arg.Any<int>()).Returns((products)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteProductHandler_ReturnOK_WhenProductExists()
        {

            // Arrange
            var existingProduct = new Faker<products>()
                .RuleFor(s => s.idProduct, f => f.Random.Int())
                .RuleFor(s => s.descriptionProduct, f => f.Name.Random.ToString())
                .RuleFor(s => s.stockQuantity, f => f.Random.Int())
                
                .Generate();
            var command = new DeleteProductCommand();

            _productsRepository.Get(Arg.Any<int>()).Returns(existingProduct);

            _productsRepository.Delete(existingProduct);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }

    }
}
