using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;
using CinemaTickets.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaTicketDbContext _context;

        public RoomRepository(CinemaTicketDbContext context)
        {
            _context = context;
        }

        public Room GetById(Id<Room> id)
        {
            return _context.Rooms
                .Include(x => x.Seances)
                .FirstOrDefault();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public void Build(Room room)
        {
            _context.Add(room);
        }
    }
}