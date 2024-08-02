using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetUsersList;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProductsList
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, GetProductsListResponse>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public GetProductsListHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<GetProductsListResponse> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductsListResponse();

            var productsList = await _productsRepository.GetAll();

            response.ProductsList = productsList

            .OrderByDescending(productsList => productsList.idProduct)
            .Select(productsList => _mapper.Map<productsDTO>(productsList))
            .ToList();
            return response;



        }
    }
}
