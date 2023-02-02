using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public class BookingRepository:IBookingRepository
    {
        public readonly TicketDALContext _ticketDAL;
        public BookingRepository(TicketDALContext ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }



        public bool AddABooking(Booking book)
        {
            Booking book1 = new Booking
            {

                // BookingId = book.BookingId,
                TotalTickets = book.TotalTickets,
                TotalCost = book.TotalCost,
                Date = book.Date,
                MovieName = book.MovieName,
                UserName = book.UserName,

            };


            _ticketDAL.Bookings.Add(book1);

            _ticketDAL.SaveChanges();
            return true;
        }

        public DbSet<Booking> GetAllBookings()
        {
            return _ticketDAL.Bookings;
        }

        public Booking GetBookingsById(int BookId)
        {
            return _ticketDAL.Bookings.Find(BookId);
        }
    }
}
