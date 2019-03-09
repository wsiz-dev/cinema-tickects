using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Entities;

namespace CinemaTickets.Domain.Service
{
    public interface  IRoomService
    {
        double GetTimeSpanBeforeSeanceDate(Room room, DateTime seanceDate, int seanceTime);
        double GetTimeSpanAfterSeanceDate(Room room, DateTime seanceDate, int seanceTime);
    }
}
