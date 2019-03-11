using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Core.Query
{
    public class GetSeanceQueryHanlder : IQueryHandler<GetSeanceQuery, MovieSeanceDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeanceQueryHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MovieSeanceDetailsDTO Handle(GetSeanceQuery query)
        {
            var movie = _unitOfWork.MoviesRepository.GetSeanceDetails(query.MovieId);
            if (movie == null)
                return null;

            var seances = movie.Seances.Where(c => c.Id == query.SeanceId).ToList();
            movie.SetCurrentSeance(seances);

            var seance = new SeanceDetailsDTO();

            if (movie.Seances == null)
                return new MovieSeanceDetailsDTO(movie.Name, movie.Id, seance);

            seance = movie.Seances.Select(
                    item => new SeanceDetailsDTO(
                        item.Date, item.Id, item.RoomId, 
                        item.Tickets.Select(
                            x => x.PeopleCount).ToList()))
                .FirstOrDefault();

            return new MovieSeanceDetailsDTO(movie.Name, movie.Id, seance);
        }
    }
}
