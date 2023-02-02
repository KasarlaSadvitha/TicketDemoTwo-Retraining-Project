using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.DataAccessLayer
{
    public class TicketDALContext:DbContext
    {
        public TicketDALContext(DbContextOptions<TicketDALContext> options) : base(options)
        {

        }

        public DbSet<TBLUserInfo> TBLUserInfoes { get; set; } // Infoees  see "e" here
        public DbSet<TBLMovieDetails> TBLMovieDetailes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

    }
}
