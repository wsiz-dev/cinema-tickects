using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Repositories
{
    public interface IRoomRepository
    {
        Room GetById(Id<Room> id);

        IEnumerable<Room> GetAll();

        void Build(Room movie);
    }
}