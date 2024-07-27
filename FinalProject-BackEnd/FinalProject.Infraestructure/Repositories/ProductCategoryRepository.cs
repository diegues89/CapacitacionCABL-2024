using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly DBContextFinalProject _dBContextFinalProject;

        public ProductCategoryRepository(DBContextFinalProject dBContextFinalProject)
        {
            _dBContextFinalProject = dBContextFinalProject;
        }

        public async Task<IEnumerable<productCategory>> GetAll()
        {
            try
            {
                return await _dBContextFinalProject.productCategory.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
