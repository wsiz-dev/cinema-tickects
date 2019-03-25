using System;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class EditMovieCommand : ICommand
    {
        public EditMovieCommand(Guid id, string name, int year, int seanceTime)
        {
            Id = id;
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }

        public Guid Id { get; }
        public string Name { get; }
        public int Year { get; }
        public int SeanceTime { get; }
    }
}