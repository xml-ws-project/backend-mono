using MonoAPI.DTOs.Flights;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.Mappers
{
    public class FlightMapper
    {

        public static FlightDTO EntityToDTO(Flight flight)
        {
            return new FlightDTO(flight.Id, flight.DeparturePlace, flight.LandingPlace, flight.Pricelist, flight.TakeOffDateTime, flight.LandingDateTime);
        }

        public static Flight NewDTOToEntity(NewFlightDTO dto, FlightLayout flightLayout)
        {
            var pricelist = new Dictionary<PassengerClass, double>
            {
                { PassengerClass.ECONOMY, dto.EconomyClassPrice },
                { PassengerClass.BUSINESS, dto.BusinessClassPrice }
            };
            return new Flight(dto.DeparturePlace, dto.LandingPlace, pricelist, dto.TakeOffDateTime, dto.LandingDateTime, new int[flightLayout.NumOfEconomy], new int[flightLayout.NumOfBusiness]);
        }

        public static List<FlightDTO> EntityListToEntityDTOList(List<Flight> flights)
        {
            List<FlightDTO> dtoList = new List<FlightDTO>();
            if (flights == null) return dtoList;
            flights.ForEach(x => dtoList.Add(EntityToDTO(x)));
            return dtoList;
        }

        public static AdminFlightDTO EntityToAdminFlightDTO(Flight flight) 
        {
            AdminFlightDTO dto = new AdminFlightDTO();
            dto.FlightDTO = EntityToDTO(flight);
            dto.RemainingEconomy = flight.GetRemainingSeats(true);
            dto.RemainingBussines = flight.GetRemainingSeats(false);
            return dto;
        }

        public static ReservationFlightResponse EntityToReservationResponse(List<Flight> start, List<Flight> end) 
        {
            var response = new ReservationFlightResponse();
            var startList = EntityListToEntityDTOList(start);
            var endList = EntityListToEntityDTOList(end);
            response.Start = startList;
            response.End = endList;
            
            return response;
        }
    }
}
