using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public class MovieRepository:IMovieRepository
    {
        public readonly TicketDALContext _ticketDAL;
        public MovieRepository(TicketDALContext ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }

        public DbSet<TBLMovieDetails> GetAllMovies()
        {
            return _ticketDAL.TBLMovieDetailes;
        }

        public TBLMovieDetails GetMovieById(int MovieId)
        {
            return _ticketDAL.TBLMovieDetailes.Find(MovieId);
        }

        public bool AddAMovie(TBLMovieDetails m)
        {
            TBLMovieDetails movie1 = new TBLMovieDetails
            {

                MovieName = m.MovieName,
                Genre = m.Genre,
                Description = m.Description,
                Language = m.Language,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Director = m.Director,
                PosterUrl = m.PosterUrl
            };


            _ticketDAL.TBLMovieDetailes.Add(movie1);

            _ticketDAL.SaveChanges();
            return true;
        }



        public bool DeleteMovie(int id)
        {
            if (id <= 0)
            {
                return false;

            }
            var currentUser = _ticketDAL.TBLMovieDetailes.Where(s => s.MovieId == id).FirstOrDefault<TBLMovieDetails>();

            if (currentUser != null)
            {
                _ticketDAL.TBLMovieDetailes.Remove(currentUser);
                _ticketDAL.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
