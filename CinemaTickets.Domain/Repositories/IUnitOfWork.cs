using System;

namespace CinemaTickets.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMoviesRepository MoviesRepository { get; }
        void Commit();
    }
}