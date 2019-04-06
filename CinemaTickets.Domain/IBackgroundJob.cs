using System;
using System.Linq.Expressions;

namespace CinemaTickets.Domain
{
    public interface IBackgroundJob
    {
        string Enqueue(Expression<Action> methodCall);
    }
}
