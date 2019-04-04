using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Seance
    {
        protected Seance()
        {
        }

        public Seance(DateTime date, Id<Movie> movieId)
        {
            Id = new Id<Seance>(Guid.NewGuid());
            Date = date;
            MovieId = movieId;
            Tickets = new List<Ticket>();
        }

        public DateTime Date { get; protected set; }

        public Id<Seance> Id { get; protected set; }

        public Id<Movie> MovieId { get; protected set; }

        public List<Ticket> Tickets { get; protected set; }

        public List<Ticket> GetTicketByEmail(string email)
        {
            return Tickets.Where(x => x.Email == email)
                .OrderBy(x => x.PurchesDate)
                .ToList();
        }

        public List<Ticket> GetAllSeanceTicket()
        {
            return Tickets == null ? new List<Ticket>() 
                : Tickets.ToList();
        }

        public void Add(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
    }
}