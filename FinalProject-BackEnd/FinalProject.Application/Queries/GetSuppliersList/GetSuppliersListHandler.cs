using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Application.Queries.GetProductsList;
using FinalProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetSuppliersList
{
    public class GetSuppliersListHandler: IRequestHandler<GetSuppliersListQuery, GetSuppliersListResponse>
    {
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;

        public GetSuppliersListHandler(ISuppliersRepository suppliersRepository, IMapper mapper)
        {
            _suppliersRepository = suppliersRepository;
            _mapper = mapper;
        }

        public async Task<GetSuppliersListResponse> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSuppliersListResponse();

            var suppliersList = await _suppliersRepository.GetAll();

            response.SuppliersList = suppliersList
            .OrderByDescending(suppliersList => suppliersList.idSupplier)
            .Select(suppliersList => _mapper.Map<SuppliersDTO>(suppliersList))
            .ToList();
            return response;
        }
    }
}
