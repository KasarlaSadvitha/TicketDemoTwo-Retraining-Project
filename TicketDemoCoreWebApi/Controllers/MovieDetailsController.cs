using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;
using TicketDemoCoreWebApi.Repository;

namespace TicketDemoCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
        MovieRepository repo;
        public MovieDetailsController(TicketDALContext c)
        {
            repo = new MovieRepository(c);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TBLMovieDetails>> GetMovies()
        {
            return repo.GetAllMovies().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TBLMovieDetails> GetMoviesByID(int id)
        {
            TBLMovieDetails movie = repo.GetMovieById(id);
            return movie;
        }


        [HttpPost]
        public IActionResult AddMovie(TBLMovieDetails movie)
        {
            return Ok(repo.AddAMovie(movie));
        }


        [HttpDelete("{id}")]
        public ActionResult<string> DeleteMovieByID(int id)
        {
            if (repo.DeleteMovie(id)) { return Ok(true); }
            else { return BadRequest(); }

        }


    }
}
