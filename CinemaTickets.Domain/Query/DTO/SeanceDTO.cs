using System;

namespace CinemaTickets.Domain.Query.DTO
{
    public class SeanceDTO
    {
        public SeanceDTO(Guid id, DateTime date)
        {
            Date = date;
            Id = id;
        }

        public Guid Id { get; }

        public DateTime? Date { get; }
    }
}