using MonoLibrary.Core.Context;
using MonoLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class FlightLayoutRepository : BaseRepository<FlightLayout>, IFlightLayoutRepository
    {
        private readonly IMongoDbContext _context;
        public FlightLayoutRepository(IMongoDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
