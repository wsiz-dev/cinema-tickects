using CSharpFunctionalExtensions;

namespace CinemaTickets.Domain.Command
{
    public interface ICommandHandler<TCommand> 
            where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
