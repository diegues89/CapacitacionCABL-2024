using FinalProject.Domain.Interfaces;
using MediatR;


namespace FinalProject.Application.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierCommand>
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public DeleteSupplierHandler( ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }
        public async Task Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplierdelete = await _suppliersRepository.Get(request.idSupplier);

            if (supplierdelete is null)
                throw new Exception("No se encontro el proveedor a eliminar");

            await _suppliersRepository.Delete(supplierdelete);
        }
    }
}
