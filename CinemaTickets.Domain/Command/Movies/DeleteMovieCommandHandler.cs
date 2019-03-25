using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Command.Movies
{
    public sealed class DeleteMovieCommandHandler : ICommandHandler<DeleteMovieCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(DeleteMovieCommand command)
        {
            var movie = _unitOfWork.MoviesRepository.GetById(new Id<Movie>(command.Id));
            if (movie == null)
            {
                return Result.Fail("Movie does not exist.");
            }

            _unitOfWork.MoviesRepository.Remove(movie);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}