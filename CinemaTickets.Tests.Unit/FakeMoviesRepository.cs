using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain;

namespace CinemaTickets.Tests.Unit
{
    public class FakeMoviesRepository : IMoviesRepository
    {
        private readonly List<Movie> _movies;

        public FakeMoviesRepository()
        {
            _movies = new List<Movie>();
        }

        public Movie GetById(Id<Movie> id)
            => _movies.SingleOrDefault(x => x.Id == id);

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }
    }
}