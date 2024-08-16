using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateProductCategory
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var newproductcategory = new productCategory
            {
                descriptionCategory = request.descriptionCategory,
                
            };
            var idCategory = await _productCategoryRepository.Create(newproductcategory);
            if (idCategory == -1)
            {
                throw new Exception("No se pudo crear la categoria");
            }
        }
    }
}
