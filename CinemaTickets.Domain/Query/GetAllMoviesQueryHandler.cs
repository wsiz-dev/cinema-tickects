using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.Query.DTO;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Domain.Query
{
    public sealed class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, List<MovieDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<MovieDto> Handle(GetAllMoviesQuery query)
        {
            var movies = _unitOfWork.MoviesRepository.GetAll();

            return movies.Select(item => new MovieDto(item.Name, item.Id)).ToList();
        }
    }
}