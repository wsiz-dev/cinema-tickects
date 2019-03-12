using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;

namespace CinemaTickets.Domain.Command
{
    public sealed class RegisterSeanceCommandHandler
        : ICommandHandler<RegisterSeanceCommand>
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterSeanceCommandHandler(IUnitOfWork unitOfWork, IRoomService roomService)
        {
            _unitOfWork = unitOfWork;
            _roomService = roomService;
        }

        public Result Handle(RegisterSeanceCommand command)
        {
            var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate, command.RoomId);
            if (isSeanceExist)
                return Result.Fail("This seance already exist");

            var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);
            if (movie == null)
                return Result.Fail("This movie does not exist");

            var seance = new Seance(command.SeanceDate, command.RoomId, command.MovieId);
            var room = _unitOfWork.RoomRepository.GetById(command.RoomId);

            if (room.Seances.Count != 0)
            {
                var timeSpanBefore =
                    _roomService.GetTimeSpanBeforeSeanceDate(room, command.SeanceDate, movie.SeanceTime);
                var timeSpanAfter = _roomService.GetTimeSpanAfterSeanceDate(room, command.SeanceDate, movie.SeanceTime);

                if (timeSpanBefore < movie.SeanceTime || timeSpanAfter < movie.SeanceTime)
                    return Result.Fail("Time Span between the films is too short ");
            }

            movie.Seances.Add(seance);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}