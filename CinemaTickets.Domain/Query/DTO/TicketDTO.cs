using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query.DTO
{
    public class TicketDetailsDTO
    {
        public TicketDetailsDTO(string email, int peopleCount, Id<Ticket> id, DateTime purchesDate)
        {
            Email = email;
            PeopleCount = peopleCount;
            Id = id;
            PurchesDate = purchesDate;
        }

        public string Email { get; }

        public Id<Ticket> Id { get; }

        public int PeopleCount { get; }

        public DateTime PurchesDate { get; }
    }
}