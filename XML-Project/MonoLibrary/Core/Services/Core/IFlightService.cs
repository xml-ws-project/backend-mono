﻿using MonoLibrary.Core.Model;
﻿using MonoLibrary.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;

namespace MonoLibrary.Core.Service.Core
{
    public interface IFlightService 
    {
        Task<bool> Add(Flight flight);
        Flight Get(string id);
        IEnumerable<Flight> GetAll();
        Task<bool> Update(Flight flight);
        Task<bool> Remove(string id); 
        IEnumerable<Flight> SearchFlights(SearchFlightDTO dto);
        bool UpdateFlight(String id, int[] seats);
        List<Flight> ReservationFlightsStart(string start, string departure, int numOfSeats);
        List<Flight> ReservationFlightsEnd(DateOnly end, string landing, int numOfSeats);
    }
}
