using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Domain
{
    public class Seance
    {
        private readonly List<Ticket> _tickets;

        public Seance(DateTime date, int seats, int roomNumber)
        {
            Date = date;
            Seats = seats;
            RoomNumber = roomNumber;
            _tickets = new List<Ticket>();
        }

        public DateTime Date { get; }
        public int Seats { get; }
        public int RoomNumber { get;}

        public List<Ticket> GetTicketByEmail(string email)
            => _tickets.Where(x => x.Email == email)
                .OrderBy(x => x.PurchesDate)
                .ToList();

        public List<Ticket> GetAllSeanceTicket()
            => _tickets.ToList();

        public void Add(Ticket ticket)
            => _tickets.Add(ticket);
    }
}