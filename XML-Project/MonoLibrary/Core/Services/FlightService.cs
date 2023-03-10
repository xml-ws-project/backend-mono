using MongoDB.Driver;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service
{
    public class FlightService : BaseService<Flight>, IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository) : base(flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Flight> SearchFlights(SearchFlightDTO dto)
        {
            List<Flight> flights = new List<Flight>();
            if (!dto.DeparturePlace.Equals(null))
            {
                var tempFlights = _flightRepository.GetCollection().Find(x => x.DeparturePlace.ToLower().Contains(dto.DeparturePlace.ToLower())).ToList();
                flights.AddRange(tempFlights);
            }
            if (!dto.LandingPlace.Equals(null))
            {
                var tempFlights = _flightRepository.GetCollection().Find(x => x.LandingPlace.ToLower().Contains(dto.LandingPlace.ToLower())).ToList();
                flights.AddRange(tempFlights);
            }
            if(dto.RemainingSeats != 0)
            {
                var tempFlights = _flightRepository.GetCollection().Find(x => x.RemainingSeats >= dto.RemainingSeats).ToList();
                flights.AddRange(tempFlights);
            }
            if (!dto.TakeOffDateTime.Equals(null))
            {
                var tempFlights = _flightRepository.GetCollection().Find(x => x.TakeOffDateTime.Equals(dto.TakeOffDateTime)).ToList();
                flights.AddRange(tempFlights);
            }
            if (!dto.LandingDateTime.Equals(null))
            {
                var tempFlights = _flightRepository.GetCollection().Find(x => x.LandingDateTime.Equals(dto.LandingDateTime)).ToList();
                flights.AddRange(tempFlights);
            }

            return flights.Distinct();
        }
    }
}
