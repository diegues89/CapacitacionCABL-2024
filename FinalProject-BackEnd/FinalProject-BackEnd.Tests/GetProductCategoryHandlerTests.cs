using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProductCategory;
using FinalProject.Application.Queries.GetSupplier;
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
    public class GetProductCategoryHandlerTests
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly Faker _faker;
        private readonly GetProductCategoryHandler _handler;

        public GetProductCategoryHandlerTests()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _mapper = Substitute.For<IMapper>();
            _faker = new Faker();
            _handler = new GetProductCategoryHandler(_productCategoryRepository, _mapper);
        }
        
        [Fact]
        public async Task GetProductCategoryHandler_ReturnEmpty_WhenProductCategoryNotExists()
        {

            // Arrange

            var idCategory = _faker.Random.Int();
            _productCategoryRepository.Get(Arg.Any<int>()).Returns((productCategory)null);
            // Act
            var request = new GetProductCategoryQuery { idCategory = idCategory };
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.productCategory);

        }
        [Fact]
        public async Task GetProductCategoryHandler_ReturnNotNull_WhenProductCategoryExists()
        {
            var idCategory = _faker.Random.Int();
            var existingProductCategory= new productCategory { idCategory = idCategory };
            var mappedSupplier = new productCategoryDTO();
            _productCategoryRepository.Get(idCategory).Returns(existingProductCategory);
            _mapper.Map<productCategoryDTO>(existingProductCategory).Returns(mappedSupplier);
            // Act
            var request = new GetProductCategoryQuery { idCategory = idCategory };
            var response = await _handler.Handle(request, CancellationToken.None);
            // Assert
            Assert.NotNull(response.productCategory);

        }
    }
}
