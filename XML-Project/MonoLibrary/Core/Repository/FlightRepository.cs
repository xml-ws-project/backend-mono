<<<<<<< HEAD
﻿using MonoLibrary.Core.Context;
=======
﻿using MongoDB.Driver;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.DTOs;
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        private readonly IMongoDbContext _context;
        public FlightRepository(IMongoDbContext context) : base(context)
        {
            _context = context;
        }
<<<<<<< HEAD
=======
        
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
    }
}
