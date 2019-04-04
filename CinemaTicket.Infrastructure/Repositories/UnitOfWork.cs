using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaTicketDbContext _context;

        public UnitOfWork(CinemaTicketDbContext context)
        {
            _context = context;
            MoviesRepository = new MoviesRepository(context);
        }

        public IMoviesRepository MoviesRepository { get; }

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