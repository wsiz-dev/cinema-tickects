using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaTickets.Domain
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly List<Movie> _movies;

        public MoviesRepository()
        {
            _movies = new List<Movie>();
        }

        public Movie GetById(Id<Movie> id)
            => _movies.SingleOrDefault(x => x.Id == id);

        public List<Movie> GetAll()
            => _movies.ToList();

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }
    }
}
