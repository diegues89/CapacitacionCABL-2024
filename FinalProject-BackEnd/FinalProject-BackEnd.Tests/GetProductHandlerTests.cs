using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProduct;
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
    public class GetProductHandlerTests
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly Faker _faker;
        private readonly GetProductHandler _handler;

        public GetProductHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _mapper = Substitute.For<IMapper>();
            _faker = new Faker();
            _handler = new GetProductHandler(_productsRepository, _mapper);
        }
        [Fact]
        public async Task GetProductHandler_ReturnEmpty_WhenProductNotExists()
        {

            // Arrange

            var productId = _faker.Random.Int();
            _productsRepository.Get(Arg.Any<int>()).Returns((products)null);
            // Act
            var request = new GetProductQuery { idProduct = productId };
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.product);

        }
        [Fact]
        public async Task GetProductHandler_ReturnNotNull_WhenProductExists()
        {
            var productId = _faker.Random.Int();
            var existingProduct = new products { idProduct = productId };
            var mappedProduct = new productsDTO();
            _productsRepository.Get(productId).Returns(existingProduct);
            _mapper.Map<productsDTO>(existingProduct).Returns(mappedProduct);
            // Act
            var request = new GetProductQuery { idProduct = productId };
            var response = await _handler.Handle(request, CancellationToken.None);
            // Assert
            Assert.NotNull(response.product);

        }
    }
}
