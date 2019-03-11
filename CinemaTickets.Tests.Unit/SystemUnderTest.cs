using System;
using System.Collections.Generic;
using CinemaTickets.Domain.Entities;

namespace CinemaTickets.Tests.Unit
{
    public class SystemUnderTest : IDisposable
    {
        public SystemUnderTest()
        {
            Rooms = CreateRooms();
        }

        public List<Room> Rooms { get; }

        public void Dispose()
        {
        }

        private static List<Room> CreateRooms()
        {
            var rooms = new List<Room>
            {
                new Room(1, 20),
                new Room(2, 2),
                new Room(3, 20)
            };

            return rooms;
        }

        public Movie CreateMovie(string name, int year, int seanceTime)
        {
            var movie = new Movie(name, year, seanceTime);
            var seances = new List<Seance>
            {
                new Seance(new DateTime(2019, 2, 28, 13, 0, 0), Rooms[0].Id, movie.Id),
                new Seance(new DateTime(2019, 3, 1, 14, 0, 0), Rooms[1].Id, movie.Id),
                new Seance(new DateTime(2019, 3, 1, 17, 0, 0), Rooms[2].Id, movie.Id)
            };

            movie.Seances.AddRange(seances);

            return movie;
        }
    }
}