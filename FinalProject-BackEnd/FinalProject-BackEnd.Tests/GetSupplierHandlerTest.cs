using AutoMapper;
using Bogus;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetSupplier;
using FinalProject.Application.Queries.GetUser;
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
    public class GetSupplierHandlerTest
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;
        private readonly Faker _faker;
        private readonly GetSupplierHandler _handler;

        public GetSupplierHandlerTest()
        {
            _suppliersRepository = Substitute.For<ISuppliersRepository>();
            _mapper = Substitute.For<IMapper>();
            _faker = new Faker();
            _handler = new GetSupplierHandler( _suppliersRepository, _mapper );
        }

        [Fact]
        public async Task GetSupplierHandler_ReturnEmpty_WhenSupplierNotExists()
        {
            
            // Arrange
            
            var supplierId = _faker.Random.Int();
            _suppliersRepository.Get(Arg.Any<int>()).Returns((Suppliers)null);
            // Act
            var request = new GetSupplierQuery { idSupplier = supplierId };
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response.Supplier);
            
        }
        [Fact]
        public async Task GetSupplierHandler_ReturnNotNull_WhenSupplierExists()
        { 
            var supplierId = _faker.Random.Int();
            var existingSupplier= new Suppliers { idSupplier = supplierId };
            var mappedSupplier = new SuppliersDTO();
            _suppliersRepository.Get(supplierId).Returns(existingSupplier);
            _mapper.Map<SuppliersDTO>(existingSupplier).Returns(mappedSupplier);
            // Act
            var request = new GetSupplierQuery { idSupplier = supplierId };
            var response = await _handler.Handle(request, CancellationToken.None);
            // Assert
            Assert.NotNull(response.Supplier);
            
        }
    }
}
