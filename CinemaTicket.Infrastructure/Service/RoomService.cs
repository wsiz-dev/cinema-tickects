using System;
using System.Linq;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using MoreLinq;

namespace CinemaTickets.Infrastructure.Service
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public double GetTimeSpanBeforeSeanceDate(Room room, DateTime seanceDate, int seanceTime)
        {
            if (!room.Seances.Any(x => x.Date < seanceDate))
                return seanceTime;

            var closestSeanceBefore =
                room.Seances.Where(x => x.Date < seanceDate)
                    .MinBy(x => Math.Abs((x.Date - seanceDate).Ticks)).FirstOrDefault();

            var timeMovieBefore = _unitOfWork.MoviesRepository.GetMovieTimeById(closestSeanceBefore.MovieId);

            return (seanceDate - closestSeanceBefore.Date).TotalMinutes - timeMovieBefore;
        }

        public double GetTimeSpanAfterSeanceDate(Room room, DateTime seanceDate, int seanceTime)
        {
            if (!room.Seances.Any(x => x.Date > seanceDate))
                return seanceTime;

            var closestSeanceAfter =
                room.Seances.Where(x => x.Date > seanceDate)
                    .MinBy(x => Math.Abs((seanceDate - x.Date).Ticks)).FirstOrDefault();

            return (closestSeanceAfter.Date - seanceDate).TotalMinutes - seanceTime;
        }
    }
}