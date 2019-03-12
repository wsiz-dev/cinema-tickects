using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CSharpFunctionalExtensions;

namespace CinemaTickets.Domain.Command
{
    public sealed class AddMovieCommandHandler
        : ICommandHandler<AddMovieCommand>
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
                return Result.Fail("This Movie already exist");

            var movie = new Movie(command.Name, command.Year, command.SeanceTime);

            return Result.Ok();
        }
    }
}