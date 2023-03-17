using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services.Core
{
    public interface IFlightLayoutService
    {
        IEnumerable<FlightLayout> GetAll();
        FlightLayout Get(string id);
        Task<bool> Add(FlightLayout flightLayout);
    }
}
