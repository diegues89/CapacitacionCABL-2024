using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.CreateSupplier
{
    public class CreateSupplierHandler: IRequestHandler<CreateSupplierCommand>
    {
        private readonly ISuppliersRepository _suppliersRepository;
        public CreateSupplierHandler(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository; 
        }

        public async Task Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var newsupplier = new Suppliers
            {
                name = request.name,
                CUIT = request.CUIT,
                address = request.address,
                phoneNumber = request.phoneNumber
            };
            var supplierID = await _suppliersRepository.Create(newsupplier);

            if (supplierID == -1)
            {
                throw new Exception("No se pudo crear el proveedor");
            }
        }
    }
}
