using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Seance
    {
        public Seance()
        {
        }

        public Seance(DateTime date, Id<Room> roomId, Id<Movie> movieId)
        {
            Id = new Id<Seance>(Guid.NewGuid());
            Date = date;
            RoomId = roomId;
            MovieId = movieId;
            Tickets = new List<Ticket>();
        }


        public DateTime Date { get; }

        public Id<Seance> Id { get; }

        public Id<Room> RoomId { get; }

        public Id<Movie> MovieId { get; }

        public List<Ticket> Tickets { get; }

        public List<Ticket> GetTicketByEmail(string email)
        {
            return Tickets.Where(x => x.Email == email)
                .OrderBy(x => x.PurchesDate)
                .ToList();
        }

        public List<Ticket> GetAllSeanceTicket()
        {
            return Tickets.ToList();
        }

        public void Add(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
    }
}