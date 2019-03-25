using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.Query.DTO;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Domain.Query.Movies
{
    public class GetMovieQueryHandler : IQueryHandler<GetMovieQuery, MovieDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovieQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MovieDetailsDTO Handle(GetMovieQuery query)
        {
            var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
            if (movie == null)
                return null;

            var seances = new List<SeanceDTO>();

            if (movie.Seances != null)
                seances = movie.Seances.Select(
                        item => new SeanceDTO(
                            item.Date, item.Id, item.RoomId))
                                .ToList();

            return  new MovieDetailsDTO(movie.Id.Value, movie.Name, movie.Year, movie.SeanceTime, seances);
        }
    }
}
