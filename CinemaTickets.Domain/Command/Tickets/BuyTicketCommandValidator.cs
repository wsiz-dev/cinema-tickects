using FluentValidation;

namespace CinemaTickets.Domain.Command.Tickets
{
    internal class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
    {
        public BuyTicketCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.SeanceDate).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}