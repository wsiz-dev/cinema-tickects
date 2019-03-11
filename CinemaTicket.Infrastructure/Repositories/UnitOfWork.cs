using CinemaTickets.Domain.Repositories;
using CinemaTickets.Infrastructure;
using CinemaTickets.Infrastructure.Repositories;

namespace CinemaTicket.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaTicketDbContext _context;

        public UnitOfWork(CinemaTicketDbContext context)
        {
            _context = context;
            MoviesRepository = new MoviesRepository(context);
            RoomRepository = new RoomRepository(context);
        }

        public IMoviesRepository MoviesRepository { get; }
        public IRoomRepository RoomRepository { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}