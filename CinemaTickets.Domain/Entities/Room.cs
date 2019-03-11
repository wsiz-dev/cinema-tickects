using System;
using System.Collections.Generic;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Room
    {
        public Room()
        {
        }

        public Room(int roomNumber, int seats)
        {
            Id = new Id<Room>(Guid.NewGuid());
            RoomNumber = roomNumber;
            Seats = seats;
            Seances = new List<Seance>();
        }

        public Id<Room> Id { get; }

        public int RoomNumber { get; }

        public int Seats { get; }

        public List<Seance> Seances { get; }
    }
}