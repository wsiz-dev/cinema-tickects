using System;

namespace CinemaTickets.Domain
{
    public class Ticket
    {
        public Ticket(string email, int peopleCount)
        {
            Email = email;
            PeopleCount = peopleCount;
            PurchesDate = DateTime.UtcNow;
        }

        public string Email { get; }

        public int PeopleCount { get; }

        public DateTime PurchesDate { get; set; }
    }
}
