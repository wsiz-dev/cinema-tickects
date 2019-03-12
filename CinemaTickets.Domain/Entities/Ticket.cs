using System;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Ticket
    {
        protected Ticket()
        {
        }

        public Ticket(string email, int peopleCount)
        {
            Email = email;
            PeopleCount = peopleCount;
            PurchesDate = DateTime.UtcNow;
            Id = new Id<Ticket>(Guid.NewGuid());
        }

        public string Email { get; protected set; }

        public Id<Ticket> Id { get; protected set; }

        public int PeopleCount { get; protected set; }

        public DateTime PurchesDate { get; protected set; }
    }
}