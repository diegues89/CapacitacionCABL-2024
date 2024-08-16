using FinalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<productCategory?> Get(int idCategory);
        Task<IEnumerable<productCategory>> GetAll();
        Task<int> Create(productCategory productCategory);
        Task Update(productCategory productCategory);
        Task Delete(productCategory productCategory);
    }
}
