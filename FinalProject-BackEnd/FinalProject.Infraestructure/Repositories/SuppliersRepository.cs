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
    public class SuppliersRepository: ISuppliersRepository
    {
        private readonly DBContextFinalProject _dBContextFinalProject;

        public SuppliersRepository(DBContextFinalProject dBContextFinalProject)
        {
            _dBContextFinalProject = dBContextFinalProject;
        }

        public async Task<IEnumerable<Suppliers>> GetAll()
        {
            return await _dBContextFinalProject
            .Set<Suppliers>()
            .ToListAsync();
        }

        public async Task<Suppliers?> Get(int idSupplier)
        {
            return await _dBContextFinalProject
                .Set<Suppliers>()
                .Where(suppliers => suppliers.idSupplier == idSupplier)
                .FirstOrDefaultAsync();
        }
        public async Task<int> Create(Suppliers suppliers)
        {
            try
            {
                _dBContextFinalProject.Add(suppliers);
                var supplierID = await _dBContextFinalProject.SaveChangesAsync();
                return supplierID;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }
        public async Task Update(Suppliers suppliers)
        {
            _dBContextFinalProject.Update(suppliers);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Delete(Suppliers suppliers)
        {
            _dBContextFinalProject.Remove(suppliers);
            await _dBContextFinalProject.SaveChangesAsync();
        }
    }
}
