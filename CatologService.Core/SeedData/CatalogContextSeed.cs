using CatologService.Core.Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatologService.Core.SeedData
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertMany(GetPreconfiguredProduct());
            }

        }

        private static IEnumerable<Product> GetPreconfiguredProduct()
        {
            return new List<Product>()
          {
              new Product
              {
                  Summary = "summary",
                  Description = "Description",
                  ImageFile = "ImageFile",
                  Name = "Name",
                  Price = 45
              },
                new Product
              {
                  Summary = "summary",
                  Description = "Description",
                  ImageFile = "ImageFile",
                  Name = "Name",
                  Price = 45
              },
          };
        }
    }
}
