using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models.Enums;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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
            var flights = GetAll();
            flights = flights.Where(x => x.Deleted == false).ToArray();
            if (!string.IsNullOrWhiteSpace(dto.DeparturePlace))
            {
                flights = flights.Where(x => x.DeparturePlace.ToLower().Contains(dto.DeparturePlace.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(dto.LandingPlace))
            {
                flights = flights.Where(x => x.LandingPlace.ToLower().Contains(dto.LandingPlace.ToLower()));
            }
            if (dto.PreferredSeats != 0)
            {
                if (dto.PassengerClass == PassengerClass.ECONOMY)
                {
                    flights = flights.Where(x => x.GetRemainingSeats(true) >= dto.PreferredSeats);
                } 
                else
                {
                    flights = flights.Where(x => x.GetRemainingSeats(false) >= dto.PreferredSeats);
                    if (flights == null)
                    {
                        return null;
                    }
                }
            }
            if (!dto.TakeOffDate.Equals(null) && !dto.TakeOffDate.Equals(default(DateTime)))
            {
                flights = flights.Where(x => x.TakeOffDateTime.Date.Equals(dto.TakeOffDate.Value.Date));
            }
            if (!dto.LandingDate.Equals(null) && !dto.LandingDate.Equals(default(DateTime)))
            {
                flights = flights.Where(x => x.LandingDateTime.Date.Equals(dto.LandingDate.Value.Date));
            }

            return flights;
        }

        public bool UpdateFlight(String id, int[] seats)
        {
            Flight flight = _flightRepository.Get(id);
            flight.EconomySeats = seats;
            _flightRepository.Update(flight);
            _flightRepository.Commit(); 
            return true;
        }
        public List<Flight> FindReservationFlights(ReservationFlightRequest request)
        {
            var flights = GetAll().Where(flight => flight.DeparturePlace.Equals(request.DeparturePlace) &&
                                         flight.LandingPlace.Equals(request.LandingPlace) &&
                                         flight.TakeOffDateTime.Date.ToString("yyyy-MM-dd").Equals(request.Start) && 
                                         flight.LandingDateTime.Date.ToString("yyyy-MM-dd").Equals(request.End) &&
                                         flight.EconomySeats.Length > request.NumberOfSeats);
            return flights.ToList();
        }                
    }
}
