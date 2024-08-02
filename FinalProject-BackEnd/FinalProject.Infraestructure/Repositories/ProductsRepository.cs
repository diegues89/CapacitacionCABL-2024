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
               // return await _dBContextFinalProject.products.ToListAsync();
               List<products> productsResponse = await (from p in _dBContextFinalProject.products
                                                join pc in _dBContextFinalProject.productCategory on p.idCategory equals pc.idCategory
                                                join s in _dBContextFinalProject.Suppliers on p.idSupplier equals s.idSupplier
                                                select new products
                                                {
                                                    idProduct = p.idProduct,
                                                    descriptionProduct = p.descriptionProduct,
                                                    stockQuantity = p.stockQuantity,
                                                    idCategory = p.idCategory,
                                                    Category = pc.descriptionCategory,
                                                    idSupplier = p.idSupplier,
                                                    supplierName = s.name,
                                                }).ToListAsync();
                return productsResponse;
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
