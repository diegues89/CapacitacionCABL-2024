using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProductCategoryList;
using FinalProject.Application.Queries.GetUsersList;
using FinalProject.Applications.Models.DTOs;
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
    public class GetProductCategoryListHandlerTest
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly GetProductCategoryListHandler _handler;

        public GetProductCategoryListHandlerTest()
        {
            _productCategoryRepository = Substitute.For<IProductCategoryRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetProductCategoryListHandler(_productCategoryRepository, _mapper);
        }

        [Fact]
        public async Task GetProductCategoryListHandler_ReturnsMappedProductCategoryList_WhenProductCategoryExists()
        {
            // Arrange
            var productCategoryListFromRepository = new Faker<List<productCategory>>().Generate();

            var mappedproductCategoryList = new Faker<List<productCategoryDTO>>().Generate();

            _productCategoryRepository.GetAll().Returns(productCategoryListFromRepository);
            _mapper.Map<productCategoryDTO>(Arg.Any<productCategory>()).Returns(callInfo =>
            {
                var productCategory = callInfo.ArgAt<productCategory>(0);
                return mappedproductCategoryList.FirstOrDefault(p => p.idCategory == productCategory.idCategory);
            });
            // Act
            var request = new GetProductCategoryListQuery();
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.productCategoryList);


        }
    }
}
