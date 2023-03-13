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
        public int? RemainingSeats { get; set; }
        public string? DeparturePlace { get; set; }
        public string? LandingPlace { get; set; }

        public SearchFlightDTO() {}

        public SearchFlightDTO(DateTime takeOffDate, DateTime landingDate, int remainingSeats, string departurePlace, string landingPlace)
        {
            TakeOffDate = takeOffDate;
            LandingDate = landingDate;
            RemainingSeats = remainingSeats;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
        }
    }
}
