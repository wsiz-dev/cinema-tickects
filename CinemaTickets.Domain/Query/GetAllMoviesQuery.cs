﻿using System.Collections.Generic;
using CinemaTickets.Domain.Query.DTO;

namespace CinemaTickets.Domain.Query
{
    public sealed class GetAllMoviesQuery : IQuery<List<MovieDto>>
    {
    }
}