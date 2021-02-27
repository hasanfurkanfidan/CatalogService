using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Core.Settings.DatabaseSettings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set ; }
        public string CollectionName { get; set ; }
    }
}
