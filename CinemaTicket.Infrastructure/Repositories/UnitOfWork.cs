using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Repositories;

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

            public IMoviesRepository MoviesRepository { get; private set; }
            public IRoomRepository RoomRepository { get; private set; }

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
