using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Command.Seances
{
    internal class RegisterSeanceCommandHandler : ICommandHandler<RegisterSeanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterSeanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(RegisterSeanceCommand command)
        {
            var validationResult = new RegisterSeanceCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var movieId = new Id<Movie>(command.MovieId);

            var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate);
            if (isSeanceExist)
            {
                return Result.Fail("This seance already exist");
            }

            var movie = _unitOfWork.MoviesRepository.GetById(movieId);
            if (movie == null)
            {
                return Result.Fail("This movie does not exist");
            }

            var seance = new Seance(command.SeanceDate, movieId);

            movie.Seances.Add(seance);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}