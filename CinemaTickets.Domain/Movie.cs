using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Domain
{
    public class Movie
    {
        private List<Seance> _seance;

        public Movie(string name, int year)
        {
            Id = new Id<Movie>(Guid.NewGuid());
            Name = name;
            Year = year;
            _seance = new List<Seance>();
        }

        public Id<Movie> Id { get; }

        public string Name { get; }

        public int Year { get; }

        public void LoadSeances(IEnumerable<Seance> seance)
        {
            if (_seance.Any())
            {
                throw new InvalidOperationException("Seances are already loaded.");
            }

            _seance = seance.ToList();
        }

        public Seance GetSeanceByDateAdnRoomNumber(DateTime date, int roomNumber)
            => _seance.SingleOrDefault(x => x.Date == date && x.RoomNumber == roomNumber);
    }
}
