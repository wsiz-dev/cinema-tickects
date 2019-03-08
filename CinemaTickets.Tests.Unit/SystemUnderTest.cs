using System;
using System.Collections.Generic;
using CinemaTicket.Infrastructure;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Tests.Unit
{
    public class SystemUnderTest : IDisposable
    {
        public SystemUnderTest()
        {
            Rooms = CreateRooms();
        }

        public List<Room> Rooms { get; }

        public List<Room> CreateRooms()
        {
            var rooms = new List<Room>()
            {
                new Room(new Id<Room>(new Guid()), 1, 50),
                new Room(new Id<Room>(new Guid()), 2, 50),
                new Room(new Id<Room>(new Guid()), 3, 50)
            };

            return rooms;
        }
        
        public Movie CreateMovie(string name, int year, int seanceTime)
        {
            var movie = new Movie(name, year, seanceTime);
            var seances = new List<Seance>()
            {
                new Seance(new DateTime(2019, 2, 28, 13, 0, 0), 20, Rooms[0].Id, movie.Id),
                new Seance(new DateTime(2019, 3, 1, 14, 0, 0), 2, Rooms[1].Id, movie.Id),
                new Seance(new DateTime(2019, 3, 1, 17, 0, 0), 20, Rooms[2].Id, movie.Id)
            };

            movie.Seances.AddRange(seances);

            return movie;
        }

        public void Dispose()
        {
        }
    }
}
