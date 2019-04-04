using System;
using System.Collections.Generic;
using CinemaTickets.Domain.Entities;

namespace CinemaTickets.Tests.Unit
{
    public class SystemUnderTest : IDisposable
    {
        public void Dispose()
        {
        }

        public Movie CreateMovie(string name, int year, int seanceTime)
        {
            var movie = new Movie(name, year, seanceTime);
            var seances = new List<Seance>
            {
                new Seance(new DateTime(2019, 2, 28, 13, 0, 0), movie.Id),
                new Seance(new DateTime(2019, 3, 1, 14, 0, 0), movie.Id),
                new Seance(new DateTime(2019, 3, 1, 17, 0, 0), movie.Id)
            };

            movie.Seances.AddRange(seances);

            return movie;
        }
    }
}