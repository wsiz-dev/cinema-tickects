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

        public SeanceDetailsDTO(DateTime date, Id<Seance> id, List<int> peopleCount)
        {
            Date = date;
            Id = id;
            PeopleCount = peopleCount;
        }

        public DateTime? Date { get; }

        public Id<Seance> Id { get; }

        public List<int> PeopleCount { get; }
    }
}