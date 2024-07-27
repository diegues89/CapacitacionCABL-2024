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
        Task<IEnumerable<productCategory>> GetAll();
    }
}
