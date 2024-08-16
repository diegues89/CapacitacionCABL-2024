using Bogus;
using FinalProject.Application.Commands.UpdateProductCategory;
using FinalProject.Application.Commands.UpdateSupplier;
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
    public class UpdateProductCategoryHandlerTests
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly UpdateProductCategoryHandler _handler;

        public UpdateProductCategoryHandlerTests()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _handler = new UpdateProductCategoryHandler(_productCategoryRepository);
        }
        [Fact]
        public async Task UpdateProductCategoryHandler_ReturnError_WhenproductCategoryNotExists()
        {
            // Arrange
            var command = new UpdateProductCategoryCommand();
            //Act
            _productCategoryRepository.Get(Arg.Any<int>()).Returns((productCategory)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }
        [Fact]
        public async Task UpdateSupplierHandler_ReturnOK_WhenSupplierExists()
        {

            // Arrange

            var productCategoryFakeToUpdate = new Faker<productCategory>()
                .RuleFor(x => x.idCategory, f => f.Random.Int())
                .RuleFor(x => x.descriptionCategory, f => f.Random.Word())
                .Generate();

            var command = new UpdateProductCategoryCommand();
            _productCategoryRepository.Get(Arg.Any<int>()).Returns(productCategoryFakeToUpdate);

            _productCategoryRepository.Update(productCategoryFakeToUpdate);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
