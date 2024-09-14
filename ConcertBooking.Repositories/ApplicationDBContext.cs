using ConcertBooking.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.ConcertBooking.Repositories
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>     //DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        
        }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        

    }
}
