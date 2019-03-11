using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query.DTO
{
    public class SeanceDTO
    {
        public SeanceDTO()
        {
        }

        public SeanceDTO(DateTime date, Id<Seance> id, Id<Room> roomId)
        {
            Date = date;
            Id = id;
        }

        public DateTime? Date { get; }

        public Id<Seance> Id { get; }
    }
}