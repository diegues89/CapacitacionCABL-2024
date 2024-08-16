using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public UpdateProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productcategory = await _productCategoryRepository.Get(request.idCategory);

            if (productcategory is null)
                throw new Exception("No se encontro la categoria del producto");

            productcategory.descriptionCategory = request.descriptionCategory;
            

            await _productCategoryRepository.Update(productcategory);
        }
    }
}
