using System;
using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query.DTO
{
    public class SeanceDetailsDTO
    {
        public SeanceDetailsDTO()
        {
        }

        public SeanceDetailsDTO(DateTime date, Id<Seance> id, Id<Room> roomId, List<int> peopleCount)
        {
            Date = date;
            Id = id;
            RoomId = roomId;
            PeopleCount = peopleCount;
        }

        public DateTime? Date { get; }

        public Id<Seance> Id { get; }

        public Id<Room> RoomId { get; }

        public List<int> PeopleCount { get; }
    }
}