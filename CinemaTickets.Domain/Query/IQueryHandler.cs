﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain.Query
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
