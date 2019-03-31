using System;
using FluentValidation;

namespace CinemaTickets.Domain.Command.Seances
{
    internal class RegisterSeanceCommandValidator : AbstractValidator<RegisterSeanceCommand>
    {
        public RegisterSeanceCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.SeanceDate).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}