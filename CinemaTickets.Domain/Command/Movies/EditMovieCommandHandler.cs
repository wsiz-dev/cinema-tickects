using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class EditMovieCommandHandler : ICommandHandler<EditMovieCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(EditMovieCommand command)
        {
            var validationResult = new EditMovieCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var movie = _unitOfWork.MoviesRepository.GetById(new Id<Movie>(command.Id));
            if (movie == null)
            {
                return Result.Fail("Movie does not exist.");
            }

            movie.SetName(command.Name);
            movie.SetYear(command.Year);
            movie.SetSeanceTime(command.SeanceTime);

            _unitOfWork.MoviesRepository.Update(movie);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}