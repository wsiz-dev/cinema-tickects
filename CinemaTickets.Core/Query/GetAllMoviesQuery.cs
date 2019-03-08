using System.Collections.Generic;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query
{
    public sealed class GetAllMoviesQuery : IQuery<List<MovieDto>>
    {
    }
}