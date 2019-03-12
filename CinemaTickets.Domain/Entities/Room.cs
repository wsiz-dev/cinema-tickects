using System;
using System.Collections.Generic;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Room
    {
        protected Room()
        {
        }

        public Room(int roomNumber, int seats)
        {
            Id = new Id<Room>(Guid.NewGuid());
            RoomNumber = roomNumber;
            Seats = seats;
            Seances = new List<Seance>();
        }

        public Id<Room> Id { get; protected set; }

        public int RoomNumber { get; protected set; }

        public int Seats { get; protected set; }

        public List<Seance> Seances { get; protected set; }
    }
}