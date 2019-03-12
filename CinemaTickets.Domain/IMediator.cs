using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Query;

namespace CinemaTickets.Domain
{
    public interface IMediator
    {
        Result Command<TCommand>(TCommand command) where TCommand : ICommand;

        TResponse Query<TResponse>(IQuery<TResponse> query);

        TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
    }
}
