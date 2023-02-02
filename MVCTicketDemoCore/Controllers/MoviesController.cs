using Microsoft.AspNetCore.Mvc;
using MVCTicketDemoCore.Models;


namespace MVCTicketDemoCore.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IList<TBLMovieDetails> movieslist = new List<TBLMovieDetails>();

        public MoviesController()
        {
            client.BaseAddress = new Uri("https://localhost:7018/");
        }

        public IActionResult GetMoviesmvcAdmin() // list of all movies - no view given already used in Index/Home
        {
            response = client.GetAsync("api/MovieDetails/GetMovies").Result;
            movieslist = response.Content.ReadAsAsync<IList<TBLMovieDetails>>().Result;
            return View(movieslist);
        }

        public IActionResult GetMoviesmvcCustomer() // list of all movies - no view given already used in Index/Home
        {
            response = client.GetAsync("api/MovieDetails/GetMovies").Result;
            movieslist = response.Content.ReadAsAsync<IList<TBLMovieDetails>>().Result;
            return View(movieslist);
        }
        [HttpGet]
        public ActionResult GetMoviesByIdmvc(int id)
        {
            response = client.GetAsync("api/MovieDetails/GetMoviesByID/" + id).Result;

            var movie = response.Content.ReadAsAsync<TBLMovieDetails>().Result;

            TBLMovieDetails movie1 = new TBLMovieDetails
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                Genre = movie.Genre,
                Description = movie.Description,
                Language = movie.Language,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Director = movie.Director,
                PosterUrl = movie.PosterUrl
            };

            return View(movie1);
        }


        public ActionResult CreateMovie()
        {
            return View();
        }


        public ActionResult AddMoviemvcc(TBLMovieDetails m)
        {
            TBLMovieDetails movie = new TBLMovieDetails();
            // movie.MovieId = m.MovieId;
            movie.MovieName = m.MovieName;
            movie.Genre = m.Genre;
            movie.Description = m.Description;
            movie.Language = m.Language;
            movie.ReleaseDate = m.ReleaseDate;
            movie.Duration = m.Duration;
            movie.Director = m.Director;
            movie.PosterUrl = m.PosterUrl;
            response = client.PostAsJsonAsync("api/MovieDetails/AddMovie/", movie).Result;

            return RedirectToAction("AllMoviesListAdmin", "Movies");
        }


        [HttpDelete]
        public ActionResult DeleteMovieByIDmvc(int id)
        {
            response = client.DeleteAsync("api/MovieDetails/DeleteMovieByID/" + id).Result;
            return RedirectToAction("AllMoviesListAdmin");
        }
        public ActionResult AllMoviesList()
        {
            return RedirectToAction("GetMoviesmvcCustomer");
        }
        public ActionResult AllMoviesListAdmin()
        {
            return RedirectToAction("GetMoviesmvcAdmin");
        }

    }
}
