using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public DeleteProductCategoryHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productcategorydelete = await _productCategoryRepository.Get(request.idCategory);

            if (productcategorydelete is null)
                return;

            await _productCategoryRepository.Delete(productcategorydelete);
        }
    }
}
