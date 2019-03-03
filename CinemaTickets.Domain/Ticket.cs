namespace CinemaTickets.Domain
{
    public class Ticket
    {
        public Ticket(string email, int peopleCount)
        {
            Email = email;
            PeopleCount = peopleCount;
        }

        public string Email { get; }

        public int PeopleCount { get; }
    }
}
