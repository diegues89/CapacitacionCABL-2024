using Bogus;
using FinalProject.Application.Commands.DeleteProductCategory;
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
    public class DeleteProductCategoryHandlerTests
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly DeleteProductCategoryHandler _handler;

        public DeleteProductCategoryHandlerTests()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _handler = new DeleteProductCategoryHandler(_productCategoryRepository);
        }
        [Fact]
        public async Task DeleteProductCategoryHandler_ReturnError_WhenproductCategoryNotExists()
        {
            // Arrange
            var command = new DeleteProductCategoryCommand();
            //Act
            _productCategoryRepository.Get(Arg.Any<int>()).Returns((productCategory)null);
            Assert.ThrowsAsync(typeof(Exception), async () => await _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteProductCategoryHandler_ReturnOK_WhenproductCategoryExists()
        {

            // Arrange
            var existingproductCategory = new Faker<productCategory>()
                .RuleFor(s => s.idCategory, f => f.Random.Int())
                .RuleFor(s => s.descriptionCategory, f => f.Name.Random.ToString())                
                .Generate();
            var command = new DeleteProductCategoryCommand();

            _productCategoryRepository.Get(Arg.Any<int>()).Returns(existingproductCategory);

            _productCategoryRepository.Delete(existingproductCategory);

            //Act
            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
