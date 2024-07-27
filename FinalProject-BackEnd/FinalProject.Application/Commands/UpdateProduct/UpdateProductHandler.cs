using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public UpdateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _productsRepository.Get(request.idProduct);

            if (product is null)
                return;

            product.descriptionProduct = request.descriptionProduct;
            product.stockQuantity = request.stockQuantity;
            product.idSupplier = request.idSupplier;
            product.idCategory = request.idCategory;

            await _productsRepository.Update(product);
        }
    }
}
