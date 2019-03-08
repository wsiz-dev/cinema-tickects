using System.Linq;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;

namespace CinemaTickets.Core.Query
{
    public sealed class GetSeatsInUseQueryHandler : IQueryHandler<GetSeatsInUseQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeatsInUseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Handle(GetSeatsInUseQuery query)
        {
            var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
            var seance = movie.GetSeanceByDateAdnRoomId(query.SeanceDate, query.RoomId);
            var purchasedTickets = seance.GetAllSeanceTicket();

            return purchasedTickets.Sum(x => x.PeopleCount);
        }
    }
}