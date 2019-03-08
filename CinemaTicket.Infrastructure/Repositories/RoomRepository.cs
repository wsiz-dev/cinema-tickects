using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;
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
            => _context.Rooms
                .Include(x => x.Seances)
                .FirstOrDefault();

        public IEnumerable<Room> GetAll()
            => _context.Rooms.ToList();

        public void Build(Room room)
            => _context.Add(room);
    }
}
