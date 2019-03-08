using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Seance
    {
        private readonly List<Ticket> _tickets;

        public Seance()
        {
        }

        public Seance(DateTime date, int seats, Id<Room> roomId, Id<Movie> movieId)
        {
            Date = date;
            Seats = seats;
            RoomId = roomId;
            MovieId = movieId;
            _tickets = new List<Ticket>();
        }


        public DateTime Date { get; }

        public int Seats { get; }

        public Id<Room> RoomId { get; }
        
        public Id<Movie> MovieId { get; }

        public List<Ticket> GetTicketByEmail(string email)
        {
            return _tickets.Where(x => x.Email == email)
                .OrderBy(x => x.PurchesDate)
                .ToList();
        }

        public List<Ticket> GetAllSeanceTicket()
        {
            return _tickets.ToList();
        }

        public void Add(Ticket ticket)
        {
            _tickets.Add(ticket);
        }
    }
}