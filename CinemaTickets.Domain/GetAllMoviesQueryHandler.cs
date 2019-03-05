using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain
{
    public class GetAllMoviesQueryHandler
    {
        private readonly IMoviesRepository _moviesRepository;

        public GetAllMoviesQueryHandler(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public List<MoviesList> Handle()
        {
            var result = new List<MoviesList>();
            var movies = _moviesRepository.GetAll();

            foreach (var item in movies)
            {
                var movie = new MoviesList(item.Name, item.Id);
                result.Add(movie);
            }

            return result;
        }
    }
}
