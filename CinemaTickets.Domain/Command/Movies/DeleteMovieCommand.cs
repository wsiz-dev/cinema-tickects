using System;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class DeleteMovieCommand : ICommand
    {
        public DeleteMovieCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}