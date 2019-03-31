using System.Linq;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Command.Seances
{
    internal class RegisterSeanceCommandHandler : ICommandHandler<RegisterSeanceCommand>
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
            var validationResult = new RegisterSeanceCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var movieId = new Id<Movie>(command.MovieId);
            var room = _unitOfWork.RoomRepository.GetAll().First();

            var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate, room.Id);
            if (isSeanceExist)
            {
                return Result.Fail("This seance already exist");
            }

            var movie = _unitOfWork.MoviesRepository.GetById(movieId);
            if (movie == null)
            {
                return Result.Fail("This movie does not exist");
            }

            var seance = new Seance(command.SeanceDate, room.Id, movieId);

            movie.Seances.Add(seance);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}