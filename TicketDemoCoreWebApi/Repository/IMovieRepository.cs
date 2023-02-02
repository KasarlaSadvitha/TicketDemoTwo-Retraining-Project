using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public interface IMovieRepository
    {
        DbSet<TBLMovieDetails> GetAllMovies();
        TBLMovieDetails GetMovieById(int MovieId);

        bool AddAMovie(TBLMovieDetails movie);
        bool DeleteMovie(int id);
    }
}
