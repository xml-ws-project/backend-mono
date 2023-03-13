using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.DbSettings
{
    public interface IDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
