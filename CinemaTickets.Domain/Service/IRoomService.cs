using System;
using CinemaTickets.Domain.Entities;

namespace CinemaTickets.Domain.Service
{
    public interface IRoomService
    {
        double GetTimeSpanBeforeSeanceDate(Room room, DateTime seanceDate, int seanceTime);
        double GetTimeSpanAfterSeanceDate(Room room, DateTime seanceDate, int seanceTime);
    }
}