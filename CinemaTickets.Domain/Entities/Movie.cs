using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
        }

        public Movie(string name, int year, int seanceTime)
        {
            Id = new Id<Movie>(Guid.NewGuid());
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
            Seances = new List<Seance>();
        }

        public Id<Movie> Id { get; }

        public string Name { get; }

        public int Year { get; }

        public int SeanceTime { get; }

        public List<Seance> Seances { get; private set; }

        public Seance GetSeanceByDateAdnRoomId(DateTime date, Id<Room> roomId)
        {
            return Seances.SingleOrDefault(x => x.Date == date && x.RoomId == roomId);
        }

        public void SetCurrentSeance(List<Seance> seances)
        {
            Seances = seances;
        }
    }
}