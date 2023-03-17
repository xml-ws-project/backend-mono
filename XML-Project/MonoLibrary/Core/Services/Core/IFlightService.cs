using MonoLibrary.Core.Model;
﻿using MonoLibrary.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service.Core
{
    public interface IFlightService 
    {
        Task<bool> Add(Flight flight);
        Flight Get(string id);
        IEnumerable<Flight> GetAll();
        Task<bool> Remove(string id); 
        IEnumerable<Flight> SearchFlights(SearchFlightDTO dto);
    }
}
