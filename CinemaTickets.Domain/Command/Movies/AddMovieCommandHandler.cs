using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class AddMovieCommandHandler : ICommandHandler<AddMovieCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(AddMovieCommand command)
        {
            var isExist = _unitOfWork.MoviesRepository.IsMovieExist(command.Name, command.Year);

            if (isExist)
            {
                return Result.Fail("This Movie already exist");
            }

            var movie = new Movie(command.Name, command.Year, command.SeanceTime);
            _unitOfWork.MoviesRepository.Add(movie);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}