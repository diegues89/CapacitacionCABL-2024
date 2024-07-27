using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newproduct = new products
            {
                descriptionProduct = request.descriptionProduct,
                stockQuantity = request.stockQuantity,
                idCategory = request.idCategory,
                idSupplier = request.idSupplier,
            };
            await _productsRepository.Create(newproduct);
        }
    }
}
