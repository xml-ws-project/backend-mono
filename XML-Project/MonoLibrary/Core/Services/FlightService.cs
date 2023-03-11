﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
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
            if (!string.IsNullOrWhiteSpace(dto.DeparturePlace))
            {
                flights = flights.Where(x => x.DeparturePlace.ToLower().Contains(dto.DeparturePlace.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(dto.LandingPlace))
            {
                flights = flights.Where(x => x.LandingPlace.ToLower().Contains(dto.LandingPlace.ToLower()));
            }
            if (dto.RemainingSeats != 0)
            {
                flights = flights.Where(x => x.RemainingSeats >= dto.RemainingSeats);
            }
            if (!dto.TakeOffDate.Equals(null) && !dto.TakeOffDate.Equals(default(DateTime)))
            {
                flights = flights.Where(x => x.TakeOffDateTime.Date.Equals(dto.TakeOffDate.Date));
            }
            if (!dto.LandingDate.Equals(null) && !dto.LandingDate.Equals(default(DateTime)))
            {
                flights = flights.Where(x => x.LandingDateTime.Date.Equals(dto.LandingDate.Date));
            }

            return flights;
        }
    }
}
