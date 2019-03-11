﻿using System;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Ticket
    {
        public Ticket()
        {
        }

        public Ticket(string email, int peopleCount)
        {
            Email = email;
            PeopleCount = peopleCount;
            PurchesDate = DateTime.UtcNow;
            Id = new Id<Ticket>(Guid.NewGuid());
        }

        public string Email { get; }

        public Id<Ticket> Id { get; }

        public int PeopleCount { get; }

        public DateTime PurchesDate { get; }
    }
}