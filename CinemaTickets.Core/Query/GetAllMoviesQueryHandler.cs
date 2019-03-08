using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Core.Query
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