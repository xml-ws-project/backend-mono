using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service.Core
{
    public interface IFlightService
    {
        Task Add(Flight flight);
        Task<Flight> Get(int id);
    }
}
