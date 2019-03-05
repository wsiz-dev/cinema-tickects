using System.Collections.Generic;

namespace CinemaTickets.Domain
{
    public interface IMoviesRepository
    {
        Movie GetById(Id<Movie> id);

        List<Movie> GetAll();

        void Add(Movie movie);
    }
}
