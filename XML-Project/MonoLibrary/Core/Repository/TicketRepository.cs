using MongoDB.Driver;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Repository.Core;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class TicketRepository: BaseRepository<Ticket>, ITicketRepository
    {
        private readonly IMongoDbContext _context;
        public TicketRepository(IMongoDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAllTicketsForUser(string id)
        {   
            IMongoCollection<Ticket> tickets = _context.GetCollection<Ticket>("Ticket");
            var result = tickets.AsQueryable()
                            .Where(t => t.UserId.Equals(id))
                            .Where(t => t.Deleted == false).ToList();
            return result;
        }
        
    }
}
