using MonoLibrary.Core.Models;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service;
using MonoLibrary.Core.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services
{
    public class FlightLayoutService : BaseService<FlightLayout>, IFlightLayoutService
    {
        private readonly IFlightLayoutRepository _flightLayoutRepository;
        public FlightLayoutService(IFlightLayoutRepository flightLayoutRepository) : base(flightLayoutRepository)
        {
            _flightLayoutRepository = flightLayoutRepository;
        }
    }
}
