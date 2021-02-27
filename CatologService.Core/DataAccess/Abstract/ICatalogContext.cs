using CatologService.Core.Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatologService.Core.DataAccess.Abstract
{
    public interface ICatalogContext
    {
        public IMongoCollection<Product> Products { get; set; }
    }
}
