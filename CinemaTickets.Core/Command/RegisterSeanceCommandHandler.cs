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
            var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate, command.RoomId);

            if (isSeanceExist)
                return Result.Fail("This seance already exist");

            var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);

            if (movie == null)
                return Result.Fail("This movie does not exist");

            var seance = new Seance(command.SeanceDate, command.Quantity, command.RoomId, command.MovieId);
            var room = _unitOfWork.RoomRepository.GetById(command.RoomId);

            if (room.Seances.Count == 0)
            {
                movie.Seances.Add(seance);
                _unitOfWork.Commit();

                return Result.Ok();
            }

            double timeSpanBefore;
            double timeSpanAfter;

            if (room.Seances.Any(x => x.Date < command.SeanceDate))
            {
                var closestSeanceBefore =
                    room.Seances.Where(x => x.Date < command.SeanceDate)
                        .MinBy(x => Math.Abs((x.Date - command.SeanceDate).Ticks)).FirstOrDefault();

                var timeMovieBefore = _unitOfWork.MoviesRepository.GetMovieTimeById(closestSeanceBefore.MovieId);
                timeSpanBefore = (command.SeanceDate - closestSeanceBefore.Date).TotalMinutes - timeMovieBefore;
            }
            else
                timeSpanBefore = movie.SeanceTime;
            
            if (room.Seances.Any(x => x.Date > command.SeanceDate))
            {
                var closestSeanceAfter =
                    room.Seances.Where(x => x.Date > command.SeanceDate)
                        .MinBy(x => Math.Abs((command.SeanceDate - x.Date).Ticks)).FirstOrDefault();

                timeSpanAfter = (closestSeanceAfter.Date - command.SeanceDate).TotalMinutes - movie.SeanceTime;
            }
            else
                timeSpanAfter = movie.SeanceTime;

            if (timeSpanBefore < movie.SeanceTime || timeSpanAfter < movie.SeanceTime)
                return Result.Fail("Time Span between the films is too short ");

            movie.Seances.Add(seance);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}