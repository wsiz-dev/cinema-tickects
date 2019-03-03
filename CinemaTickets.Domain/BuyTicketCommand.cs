using System;

namespace CinemaTickets.Domain
{
    public class BuyTicketCommand
    {
        public BuyTicketCommand(Id<Movie> movieId, DateTime screeningDate, string email, int quantity)
        {
            ScreeningDate = screeningDate;
            Email = email;
            Quantity = quantity;
            MovieId = movieId;
        }

        public Id<Movie> MovieId { get; }

        public DateTime ScreeningDate { get; }

        public string Email { get; }

        public int Quantity { get; }
    }
}
