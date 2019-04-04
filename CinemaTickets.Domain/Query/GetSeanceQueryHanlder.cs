using System;
using System.Linq;
using CinemaTickets.Domain.Query.DTO;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Domain.Query
{
    public class GetSeanceQueryHanlder : IQueryHandler<GetSeanceQuery, MovieSeanceDetails>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeanceQueryHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MovieSeanceDetails Handle(GetSeanceQuery query)
        {
            var movie = _unitOfWork.MoviesRepository.GetSeanceDetails(query.MovieId);
            if (movie == null)
            {
                throw new NullReferenceException("Given movie does not exist.");
            }

            var seance = movie.Seances.SingleOrDefault(x => x.Id == query.SeanceId);
            if (seance == null)
            {
                throw new NullReferenceException("Given seance does not exist.");
            }

            return new MovieSeanceDetails(movie, seance);
        }
    }
}
