using FinalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Suppliers>> GetAll();
        Task<Suppliers?> Get(int idSupplier);
        Task<int> Create(Suppliers suppliers);
        Task Update(Suppliers suppliers);
        Task Delete(Suppliers suppliers);
    }
}
