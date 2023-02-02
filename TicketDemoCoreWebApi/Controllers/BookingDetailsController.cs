using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;
using TicketDemoCoreWebApi.Repository;

namespace TicketDemoCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        BookingRepository repo;
        public BookingDetailsController(TicketDALContext c)
        {
            repo = new BookingRepository(c);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return repo.GetAllBookings().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingsByID(int id)
        {
            Booking book = repo.GetBookingsById(id);
            return book;
        }

        [HttpPost]
        public IActionResult AddBooking(Booking book)
        {
            return Ok(repo.AddABooking(book));
        }



    }
}
