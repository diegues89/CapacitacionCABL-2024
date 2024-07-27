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
            try
            {
               var response = await _dBContextFinalProject.Suppliers.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
