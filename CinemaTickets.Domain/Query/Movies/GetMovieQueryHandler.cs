using System;
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
            {
                throw new NullReferenceException("Given movie does not exist.");
            }

            var seances = new List<SeanceDTO>();

            if (movie.Seances != null)
            {
                seances = movie.Seances
                    .Select(item => new SeanceDTO(item.Id.Value, item.Date))
                    .ToList();
            }

            return new MovieDetailsDTO(movie.Id.Value, movie.Name, movie.Year, movie.SeanceTime, seances);
        }
    }
}
