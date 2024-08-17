using FinalProject.Application.Commands.CreateUser;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FluentValidation;
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
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductHandler(IProductsRepository productsRepository, IValidator<CreateProductCommand> validator)
        {
            _productsRepository = productsRepository;
            _validator = validator;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var resultado = _validator.Validate(request);

            if (!resultado.IsValid)
            {
                var ErrorMessage = "";
                foreach (var item in resultado.Errors)
                {
                    ErrorMessage = ErrorMessage +" // " + item.ErrorMessage;
                  
                }

                throw new Exception(ErrorMessage);

            }

            var newproduct = new products
            {
                descriptionProduct = request.descriptionProduct,
                stockQuantity = request.stockQuantity,
                idCategory = request.idCategory,
                idSupplier = request.idSupplier,
            };
            var idProduct = await _productsRepository.Create(newproduct);

            if (idProduct == -1)
            {
                throw new Exception("No se pudo crear el producto");
            }
        }
    }
}
