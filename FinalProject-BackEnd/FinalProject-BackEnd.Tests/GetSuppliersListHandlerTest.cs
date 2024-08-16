using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetSupplier;
using FinalProject.Application.Queries.GetSuppliersList;
using FinalProject.Application.Queries.GetUsersList;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BackEnd.Tests
{
    public class GetSuppliersListHandlerTest
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;
        private readonly GetSuppliersListHandler _handler;

        public GetSuppliersListHandlerTest()
        {
            _suppliersRepository = Substitute.For<ISuppliersRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetSuppliersListHandler(_suppliersRepository, _mapper);
        }

        [Fact]
        public async Task GetSuppliersListHandler_ReturnsMappedSupplierList_WhenSuppliersExists()
        {
            // Arrange
            var SupplierListFromRepository = new Faker<List<Suppliers>>().Generate();

            var mapperdSupplierList = new Faker<List<SuppliersDTO>>().Generate();


            _suppliersRepository.GetAll().Returns(SupplierListFromRepository);
            _mapper.Map<SuppliersDTO>(Arg.Any<Suppliers>()).Returns(callInfo =>
            {
                var supplier = callInfo.ArgAt<Suppliers>(0);
                return mapperdSupplierList.FirstOrDefault(s => s.idSupplier == supplier.idSupplier);
            });
            // Act
            var request = new GetSuppliersListQuery();
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response.SuppliersList);

        }
        
    }
}
