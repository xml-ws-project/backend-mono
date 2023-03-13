<<<<<<< HEAD
﻿using MonoLibrary.Core.Model;
=======
﻿using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
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
<<<<<<< HEAD
        Task<bool> Remove(string id); 
=======
        Task<bool> Remove(string id);
        IEnumerable<Flight> SearchFlights(SearchFlightDTO dto);
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
    }
}
