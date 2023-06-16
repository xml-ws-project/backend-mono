using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.DTOs
{
    public class ReservationFlightRequest
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string DeparturePlace { get; set; }
        public string LandingPlace { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
