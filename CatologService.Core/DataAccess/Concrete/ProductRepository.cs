using CatologService.Core.DataAccess.Abstract;
using CatologService.Core.Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatologService.Core.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task CreateAsync(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Id, product.Id);
          var result =  await _catalogContext.Products.DeleteOneAsync(filter);
            if (result.IsAcknowledged&&result.DeletedCount>0)
            {
                return true;
            }
            return false;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Id == id);
            return await _catalogContext.Products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string categoryName)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Category == categoryName);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Name == name);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Id, product.Id);
            var result = await _catalogContext.Products.ReplaceOneAsync(filter,product);
            if (result.IsAcknowledged&&result.ModifiedCount>0)
            {
                return true;
            }
            return false;
        }
    }
}
