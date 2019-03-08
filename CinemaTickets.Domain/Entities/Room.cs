using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Room
    {
        private Room()
        {
            
        }
        public Room(Id<Room> id, int roomNumber, int seats)
        {
            Id = id;
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
