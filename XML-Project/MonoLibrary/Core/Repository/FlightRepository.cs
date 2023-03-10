using MongoDB.Driver;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.DTOs;
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
        private IMongoCollection<Flight> _flights;
        public FlightRepository(IMongoDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
