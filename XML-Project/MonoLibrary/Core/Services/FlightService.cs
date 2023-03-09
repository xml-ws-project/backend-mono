using MongoDB.Driver;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service
{
    public class FlightService : BaseService<Flight>, IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FlightService(IUnitOfWork unitOfWork, IFlightRepository flightRepository) : base(unitOfWork, flightRepository)
        {
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }

        public override async Task Add(Flight flight)
        {
            try
            {
                await _flightRepository.Add(flight);
                await _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw;
            }        
        }

        public override async Task<Flight> Get(int id)
        {
            try
            {
                var flight = await _flightRepository.Get(id);
                return flight;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
