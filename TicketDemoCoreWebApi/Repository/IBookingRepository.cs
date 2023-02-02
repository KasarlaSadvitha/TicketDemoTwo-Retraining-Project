using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public interface IBookingRepository
    {
        DbSet<Booking> GetAllBookings();
        Booking GetBookingsById(int BookId);

        bool AddABooking(Booking book);
    }
}
