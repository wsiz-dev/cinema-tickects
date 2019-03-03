using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTickets.Domain
{
    public class Screening
    {
        private readonly List<Ticket> _tickets;

        public Screening(DateTime date)
        {
            Date = date;
            _tickets = new List<Ticket>();
        }

        public DateTime Date { get; }

        public Ticket GetTicketByEmail(string email)
            => _tickets.SingleOrDefault(x => x.Email == email);
    }
}