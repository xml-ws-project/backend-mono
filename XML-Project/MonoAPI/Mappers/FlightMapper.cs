﻿using MonoAPI.DTOs.Flights;
using MonoLibrary.Core.Model;

namespace MonoAPI.Mappers
{
    public class FlightMapper
    {

        public static FlightDTO EntityToDTO(Flight flight)
        {
            return new FlightDTO(flight.Id, flight.DeparturePlace, flight.LandingPlace, flight.Pricelist, flight.TakeOffDateTime, flight.LandingDateTime, flight.RemainingSeats, flight.Capacity);
        }

        public static Flight NewDTOToEntity(NewFlightDTO dto)
        {
            return new Flight(dto.DeparturePlace, dto.LandingPlace, dto.Pricelist, dto.TakeOffDateTime, dto.LandingDateTime, dto.Capacity, dto.Capacity);
        }

        public static List<FlightDTO> EntityListToEntityDTOList(List<Flight> flights)
        {
            List<FlightDTO> dtoList = new List<FlightDTO>();
            if (flights == null) return dtoList;
            flights.ForEach(x => dtoList.Add(EntityToDTO(x)));
            return dtoList;
        }
    }
}
