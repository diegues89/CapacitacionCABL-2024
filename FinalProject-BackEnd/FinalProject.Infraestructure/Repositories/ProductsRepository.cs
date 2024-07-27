using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Infrastructure.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly DBContextFinalProject _dBContextFinalProject;

        public ProductsRepository(DBContextFinalProject dBContextFinalProject)
        {
            _dBContextFinalProject = dBContextFinalProject;
        }
        public async Task<IEnumerable<products>> GetAll()
        {
            try
            {
                return await _dBContextFinalProject.products.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<products?> Get(int idProduct)
        {
            return await _dBContextFinalProject
                .Set<products>()
                .Where(products => products.idProduct == idProduct)
                .FirstOrDefaultAsync();
        }
        public async Task Create(products products)
        {
            _dBContextFinalProject.Add(products);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Update(products products)
        {
            _dBContextFinalProject.Update(products);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Delete(products products)
        {
            _dBContextFinalProject.Remove(products);
            await _dBContextFinalProject.SaveChangesAsync();
        }
    }
}
