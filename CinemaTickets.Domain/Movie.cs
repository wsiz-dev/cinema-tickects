using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Domain
{
    public class Movie
    {
        private List<Screening> _screenings;

        public Movie(string name, int year)
        {
            Id = new Id<Movie>(Guid.NewGuid());
            Name = name;
            Year = year;
            _screenings = new List<Screening>();
        }

        public Id<Movie> Id { get; }

        public string Name { get; }

        public int Year { get; }

        public void LoadScreenings(IEnumerable<Screening> screenings)
        {
            if (_screenings.Any())
            {
                throw new InvalidOperationException("Screenings are already loaded.");
            }

            _screenings = screenings.ToList();
        }

        public Screening GetScreeningByDate(DateTime date)
            => _screenings.SingleOrDefault(x => x.Date == date);
    }
}
