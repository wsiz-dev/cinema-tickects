using System;
using System.Linq;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CSharpFunctionalExtensions;
using MoreLinq;

namespace CinemaTickets.Core.Command
{
    public sealed class RegisterSeanceCommandHandler
        : ICommandHandler<RegisterSeanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterSeanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(RegisterSeanceCommand command)
        {
            var seance = new Seance(command.SeanceDate, command.Quantity, command.RoomId, command.MovieId);

            var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate, command.RoomId);

            if (isSeanceExist)
                return Result.Fail("This seance already exist");

            var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);
            if (movie == null)
                return Result.Fail("This movie does not exist");

            var room = _unitOfWork.RoomRepository.GetById(command.RoomId);

            if (room.Seances.Count == 0 || room.Seances.Count == 1)
            {
                movie.Seances.Add(seance);

                _unitOfWork.Commit();

                return Result.Ok();
            }

            var nearestAfter = 
                room.Seances.MinBy(x => Math.Abs((x.Date - command.SeanceDate).Ticks)).FirstOrDefault();
            var nearestBefore = 
                room.Seances.MinBy(x => Math.Abs((command.SeanceDate - x.Date).Ticks)).FirstOrDefault();

            double timeSpanBefore;
            double timeSpanAfter;

            if (nearestAfter.RoomId == null && nearestBefore.RoomId == null)
            {
                timeSpanBefore = movie.SeanceTime;
                timeSpanAfter = movie.SeanceTime;
            }
            else if (nearestBefore.RoomId == null)
            {
                timeSpanBefore = movie.SeanceTime;
                timeSpanAfter = (nearestAfter.Date - command.SeanceDate).TotalMinutes - movie.SeanceTime;
            }
            else if (nearestAfter.RoomId == null)
            {
                var timeMovieBefore = _unitOfWork.MoviesRepository.GetMovieTimeById(nearestBefore.MovieId);
                timeSpanBefore = (command.SeanceDate - nearestBefore.Date).TotalMinutes - timeMovieBefore;
                timeSpanAfter = movie.SeanceTime;
            }
            else
            {
                var timeMovieBefore = _unitOfWork.MoviesRepository.GetMovieTimeById(nearestBefore.MovieId);
                timeSpanBefore = (command.SeanceDate - nearestBefore.Date).TotalMinutes - timeMovieBefore;
                timeSpanAfter = (nearestBefore.Date - command.SeanceDate).TotalMinutes - timeMovieBefore;
            }

            if (timeSpanBefore < movie.SeanceTime || timeSpanAfter < movie.SeanceTime)
                return Result.Fail("Time Span between the films is too short ");

            movie.Seances.Add(seance);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}