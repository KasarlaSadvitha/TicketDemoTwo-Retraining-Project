using Microsoft.AspNetCore.Mvc;
using MVCTicketDemoCore.Models;


namespace MVCTicketDemoCore.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IList<Booking> bookingslist = new List<Booking>();
        public BookingsController()
        {
            client.BaseAddress = new Uri("https://localhost:7018/");
        }

        public IActionResult GetBookingsmvc() // list of all movies - no view given already used in Index/Home
        {
            response = client.GetAsync("api/BookingDetails/GetBookings").Result;
            bookingslist = response.Content.ReadAsAsync<IList<Booking>>().Result;
            return View(bookingslist);
        }
        [HttpGet]
        public ActionResult GetBookingsByIdmvc(int id)
        {
            response = client.GetAsync("api/BookingDetails/GetBookingsByID/" + id).Result;

            var book = response.Content.ReadAsAsync<Booking>().Result;

            Booking book1 = new Booking
            {
                BookingId = book.BookingId,
                TotalTickets = book.TotalTickets,
                TotalCost = book.TotalCost,
                Date = book.Date,
                MovieName = book.MovieName,
                UserName = book.UserName,
            };

            return View(book1);
        }
        [HttpGet]
        public ActionResult AddBookingmvc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBookingmvcc(Booking b)
        {
            Booking book2 = new Booking
            {
                //BookingId = b.BookingId,
                TotalTickets = b.TotalTickets,
                TotalCost = b.TotalCost,
                Date = b.Date,
                MovieName = b.MovieName,
                UserName = b.UserName
            };
            response = client.PostAsJsonAsync("api/BookingDetails/AddBooking/", book2).Result;

            return RedirectToAction("AllBookingsListAdmin", "Bookings");
        }

        [HttpGet]
        public ActionResult BookingMovie1(int MID)
        {
            response = client.GetAsync("api/MovieDetails/GetMoviesByID/" + MID).Result;

            var movie = response.Content.ReadAsAsync<TBLMovieDetails>().Result;

            TBLMovieDetails m1 = new TBLMovieDetails();

            m1.MovieId = movie.MovieId;

            m1.MovieName = movie.MovieName;
            m1.Genre = movie.Genre;
            m1.Description = movie.Description;
            m1.Language = movie.Language;
            m1.ReleaseDate = movie.ReleaseDate;
            m1.Duration = movie.Duration;
            m1.Director = movie.Director;
            m1.PosterUrl = movie.PosterUrl;

            return View(m1);


        }

        [HttpPost]
        public ActionResult ConfirmBooking(int MovieId, int TotalTickets)
        {
            ViewBag.TotalTickets = TotalTickets;
            int totalTickets = TotalTickets;
            int movieId = MovieId;

            //***********************************************
            response = client.GetAsync("api/MovieDetails/GetMoviesByID/" + movieId).Result;

            var movie = response.Content.ReadAsAsync<TBLMovieDetails>().Result;

            TBLMovieDetails m1 = new TBLMovieDetails();

            m1.MovieId = movie.MovieId;

            m1.MovieName = movie.MovieName;
            m1.Genre = movie.Genre;
            m1.Description = movie.Description;
            m1.Language = movie.Language;
            m1.ReleaseDate = movie.ReleaseDate;
            m1.Duration = movie.Duration;
            m1.Director = movie.Director;
            m1.PosterUrl = movie.PosterUrl;
            //*******************************************
            //m1
            Booking book = new Booking();
            book.TotalTickets = totalTickets;
            string us = "Sadvitha";
            book.UserName = us;
            book.MovieName = m1.MovieName;
            book.Date = m1.ReleaseDate;
            double Cost = 100 * totalTickets;
            book.TotalCost = Cost;

            ViewBag.Pricepp = 102;
            ViewBag.Url = m1.PosterUrl;
            ViewBag.MovieId = m1.MovieId;
            ViewBag.MovieName = m1.MovieName;
            ViewBag.Language = m1.Language;
            ViewBag.Genre = m1.Genre;
            ViewBag.Director = m1.Director;
            ViewBag.Duration = m1.Duration;
            ViewBag.ReleseDate = m1.ReleaseDate;

            //response = client.PostAsJsonAsync("api/MovieDetails/AddMovie/", book).Result;
            response = client.PostAsJsonAsync("api/BookingDetails/AddBooking/", book).Result;

            //db.Bookings.Add(book);
            //db.SaveChanges();
            return View(book);



        }
        [HttpGet]
        public ActionResult AllBookingsListAdmin()
        {
            return RedirectToAction("GetBookingsmvc");
        }



    }
}
