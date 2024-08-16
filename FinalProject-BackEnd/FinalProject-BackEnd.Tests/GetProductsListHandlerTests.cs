using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProductsList;
using FinalProject.Application.Queries.GetSuppliersList;
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
    public class GetProductsListHandlerTests
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly GetProductsListHandler _handler;

        public GetProductsListHandlerTests()
        {
            _productsRepository = Substitute.For<IProductsRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetProductsListHandler(_productsRepository, _mapper);
        }
        [Fact]
        public async Task GetProductListHandler_ReturnsMappedProductList_WhenProductsExists()
        {
            // Arrange
            var ProductListFromRepository = new Faker<List<products>>().Generate();

            var mapperdProductsList = new Faker<List<productsDTO>>().Generate();


            _productsRepository.GetAll().Returns(ProductListFromRepository);
            _mapper.Map<productsDTO>(Arg.Any<products>()).Returns(callInfo =>
            {
                var product = callInfo.ArgAt<products>(0);
                return mapperdProductsList.FirstOrDefault(s => s.idProduct == product.idProduct);
            });
            // Act
            var request = new GetProductsListQuery();
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.ProductsList);

        }
    }
}
