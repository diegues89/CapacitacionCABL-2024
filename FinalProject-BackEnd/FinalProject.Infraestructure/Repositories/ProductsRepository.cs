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
           
            return await _dBContextFinalProject
             .Set<products>()
             .Include(x => x.category)
             .Include(y => y.suppliers)
             .ToListAsync();
            
            
        }
        public async Task<products?> Get(int idProduct)
        {
            return await _dBContextFinalProject
                .Set<products>()
                .Include(x => x.category)
                .Include(y => y.suppliers)
                .Where(products => products.idProduct == idProduct)
                .FirstOrDefaultAsync();
        }
        public async Task<int> Create(products products)
        {
            try
            {
                _dBContextFinalProject.Add(products);
                var idProduct = await _dBContextFinalProject.SaveChangesAsync();
                return idProduct;
            }
            catch (Exception)
            {
                return -1;
            }
            
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
