using CinemaTickets.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class GetAllMoviesQueryTest
    {
        [Fact]
        public void GetMovies_WhenItsExist_SchouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001);
                sut.MoviesRepository.Add(movie);
                var seanceDate = new DateTime(2019, 3, 1, 14, 0, 0);

                var query = new GetAllMoviesQuery();
                var queryHandler = new GetAllMoviesQueryHandler(sut.MoviesRepository);

                var movies = queryHandler.Handle();

                movies.Count.Equals(1);
            }
        }

        [Fact]
        public void GetMovies_WhenItsExist_ReturnCorrectData()
        {
            using (var sut = new SystemUnderTest())
            {
                var movieName = "Harry Potter";
                var movie = sut.CreateMovie(movieName, 2001);
                sut.MoviesRepository.Add(movie);
                var seanceDate = new DateTime(2019, 3, 1, 14, 0, 0);

                var query = new GetAllMoviesQuery();
                var queryHandler = new GetAllMoviesQueryHandler(sut.MoviesRepository);

                var movies = queryHandler.Handle();

                movies[0].Name.Equals(movieName);
            }
        }
    }
}
