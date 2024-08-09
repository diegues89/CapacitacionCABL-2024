using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetUser;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetSupplier
{
    public class GetSupplierHandler : IRequestHandler<GetSupplierQuery, GetSupplierResponse>
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;

        public GetSupplierHandler(ISuppliersRepository suppliersRepository, IMapper mapper)
        {
            _suppliersRepository = suppliersRepository;
            _mapper = mapper;
        }
        public async Task<GetSupplierResponse> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSupplierResponse();

            var supplier = await _suppliersRepository.Get(request.idSupplier);

            if (supplier is null)
                return response;

            response.Supplier = _mapper.Map<SuppliersDTO>(supplier);

            return response;
        }
    }
}
