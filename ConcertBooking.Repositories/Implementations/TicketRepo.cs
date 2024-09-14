using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.ConcertBooking.Repositories;

namespace ConcertBooking.Repositories.Implementations
{
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationDBContext _context;

        public TicketRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<int>> GetBookedTickets(int id)
        {
            var bookedTickets = await _context.Tickets.Where(t => t.ConcertId == id && t.IsBooked)
                .Select(t => t.SeatNumber).ToListAsync();
            return bookedTickets;
        }
    }
}
