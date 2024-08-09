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

namespace FinalProject.Application.Queries.GetProductCategory
{
    public class GetProductCategoryHandler : IRequestHandler<GetProductCategoryQuery, GetProductCategoryResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<GetProductCategoryResponse> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductCategoryResponse();

            var productcategory = await _productCategoryRepository.Get(request.idCategory);

            if (productcategory is null)
                return response;

            response.productCategory = _mapper.Map<productCategoryDTO>(productcategory);

            return response;
        }
    }
}
