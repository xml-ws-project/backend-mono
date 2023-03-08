using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public DatabaseConfiguration DBConfig;
        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; }
            public string DataBaseName { get; set; }
            public string CollectionName { get; set; }
        }
    }
}
