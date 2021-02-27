using CatologService.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatologService.Core.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<List<Product>> GetProductsByCategoryAsync(string categoryName);
        Task<Product> GetProductByIdAsync(string id);
        Task CreateAsync(Product product);
        Task<bool> DeleteAsync(Product product);
        Task<bool> UpdateAsync(Product product);
    }
}
