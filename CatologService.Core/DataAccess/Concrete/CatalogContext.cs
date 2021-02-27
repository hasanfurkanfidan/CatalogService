using CatalogService.Core.Settings.DatabaseSettings;
using CatologService.Core.DataAccess.Abstract;
using CatologService.Core.Entities.Concrete;
using CatologService.Core.SeedData;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatologService.Core.DataAccess.Concrete
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IDatabaseSetting databaseSetting)
        {
            var client = new MongoClient(databaseSetting.ConnectionString);
            var database = client.GetDatabase(databaseSetting.DatabaseName);
            Products = database.GetCollection<Product>(databaseSetting.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
