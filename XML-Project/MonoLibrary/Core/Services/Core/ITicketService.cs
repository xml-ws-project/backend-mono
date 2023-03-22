using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services.Core
{
    public interface ITicketService
    {
        Task<bool> Add(Ticket ticket);
        Ticket Get(string id);
        bool Create(CreateTicketDTO dto);
        IEnumerable<Ticket> GetActiveTicketsForUser(string id);
        Task<bool> Remove(string id);
    }
}
