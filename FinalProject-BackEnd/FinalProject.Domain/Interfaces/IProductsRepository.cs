using FinalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<products>> GetAll();
        Task<products?> Get(int idProduct);
        Task<int> Create(products products);
        Task Update(products products);
        Task Delete(products products);
    }
}
