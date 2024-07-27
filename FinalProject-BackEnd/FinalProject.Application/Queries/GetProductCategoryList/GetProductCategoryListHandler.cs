using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProductsList;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetProductCategoryList
{
    public class GetProductCategoryListHandler : IRequestHandler<GetProductCategoryListQuery, GetProductCategoryListResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryListHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public  async Task<GetProductCategoryListResponse> Handle(GetProductCategoryListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductCategoryListResponse();

            var productsCategoryList = await _productCategoryRepository.GetAll();

            response.productCategoryList = productsCategoryList
            .OrderByDescending(productsCategoryList => productsCategoryList.idCategory)
            .Select(productsCategoryList => _mapper.Map<productCategoryDTO>(productsCategoryList))
            .ToList();
            return response;
        }
    }
}
