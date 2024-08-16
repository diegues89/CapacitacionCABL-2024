using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Commands.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand>
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public UpdateSupplierHandler(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }
        public async Task Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _suppliersRepository.Get(request.idSupplier);

            if (supplier is null)
                throw new Exception("No se encontro el proveedor");
            supplier.name = request.name;
            supplier.CUIT = request.CUIT;
            supplier.address = request.address;
            supplier.phoneNumber = request.phoneNumber;

            await _suppliersRepository.Update(supplier);
        }
    }
}
