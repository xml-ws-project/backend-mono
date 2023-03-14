using MonoLibrary.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.DTOs
{
    public class SearchFlightDTO
    {
        public DateTime TakeOffDate { get; set; }
        public DateTime LandingDate { get; set; }
        public int? PreferredSeats { get; set; }
        public string? DeparturePlace { get; set; }
        public string? LandingPlace { get; set; }
        public PassengerClass PassengerClass { get; set; }

        public SearchFlightDTO() {}

        public SearchFlightDTO(DateTime takeOffDate, DateTime landingDate, int preferredSeats, string departurePlace, string landingPlace, PassengerClass passengerClass)
        {
            TakeOffDate = takeOffDate;
            LandingDate = landingDate;
            PreferredSeats = preferredSeats;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            PassengerClass = passengerClass;
        }
    }
}
