using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetSupplier;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductResponse();

            var product = await _productsRepository.Get(request.idProduct);

            if (product is null)
                return response;

            response.product = _mapper.Map<productsDTO>(product);

            return response;
        }
    }
}
