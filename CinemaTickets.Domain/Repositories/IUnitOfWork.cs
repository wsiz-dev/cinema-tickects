using System;

namespace CinemaTickets.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMoviesRepository MoviesRepository { get; }
        IRoomRepository RoomRepository { get; }

        void Commit();
    }
}