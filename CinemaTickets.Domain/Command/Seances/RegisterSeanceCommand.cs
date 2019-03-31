using System;

namespace CinemaTickets.Domain.Command.Seances
{
    public class RegisterSeanceCommand : ICommand
    {
        public Guid MovieId { get; set; }

        public DateTime SeanceDate { get; set; }
    }
}