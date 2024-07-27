using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.DeleteProduct
{
    public class DeleteProductHandler: IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productdelete = await _productsRepository.Get(request.idProduct);

            if (productdelete is null)
                return;

            await _productsRepository.Delete(productdelete);
        }
    }
}
