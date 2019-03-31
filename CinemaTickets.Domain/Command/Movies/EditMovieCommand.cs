using System;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class EditMovieCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int SeanceTime { get; set; }
    }
}