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
        public async Task<productCategory?> Get(int idCategory)
        {
            return await _dBContextFinalProject
               .Set<productCategory>()
               .Where(p => p.idCategory == idCategory)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<productCategory>> GetAll()
        {
            return await _dBContextFinalProject
              .Set<productCategory>()         
              .ToListAsync();
        }
        public async Task Create(productCategory productCategory)
        {
            _dBContextFinalProject.Add(productCategory);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Update(productCategory productCategory)
        {
            _dBContextFinalProject.Update(productCategory);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Delete(productCategory productCategory)
        {
            _dBContextFinalProject.Remove(productCategory);
            await _dBContextFinalProject.SaveChangesAsync();
        }
    }
}
