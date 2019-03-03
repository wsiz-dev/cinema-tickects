using System;
using System.Collections.Generic;
using CinemaTickets.Domain;

namespace CinemaTickets.Tests.Unit
{
    public class SystemUnderTest : IDisposable
    {
        private readonly FakeMoviesRepository _fakeMoviesRepository;

        public SystemUnderTest()
        {
            _fakeMoviesRepository = new FakeMoviesRepository();
        }

        public IMoviesRepository MoviesRepository => _fakeMoviesRepository;

        public Movie CreateMovie(string name, int year)
        {
            var screenings = new List<Screening>()
            {
                new Screening(new DateTime(2019, 2, 28, 13, 0, 0)),
                new Screening(new DateTime(2019, 3, 1, 14, 0, 0)),
                new Screening(new DateTime(2019, 3, 1, 17, 0, 0))
            };

            var movie = new Movie(name, year);
            movie.LoadScreenings(screenings);

            return movie;
        }

        public void Dispose()
        {
        }
    }
}
