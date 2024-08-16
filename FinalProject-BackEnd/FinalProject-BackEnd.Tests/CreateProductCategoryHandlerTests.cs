using Bogus;
using FinalProject.Application.Commands.CreateProductCategory;
using FinalProject.Application.Commands.CreateSupplier;
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
    public class CreateProductCategoryHandlerTests
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly CreateProductCategoryHandler _handler;

        public CreateProductCategoryHandlerTests()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _handler = new CreateProductCategoryHandler(_productCategoryRepository);
        }
        [Fact]
        public async Task CreateProductCategoryHandler_ReturnsNoError_WhenRequestIsValid()
        {
            //Arrange

            var command = new Faker<CreateProductCategoryCommand>()
                .RuleFor(x => x.descriptionCategory, f => f.Random.Word())
            .Generate();

            _productCategoryRepository.Create(Arg.Any<productCategory>()).Returns(1);
            //Act
            await _handler.Handle(command, CancellationToken.None);
            //Assert
        }

        [Fact]
        public async Task CreateProductCategoryHandler_ReturnsError_WhenRequestIsNotValid()
        {
            //Arrange
            var command = new CreateProductCategoryCommand();
            _productCategoryRepository.Create(Arg.Any<productCategory>()).Returns(-1);
            //Act

            //Assert
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
