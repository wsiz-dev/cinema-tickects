using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Command.Tickets;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.ValueObjects;
using CinemaTickets.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{movieId}/{seanceId}")]
        public IActionResult Index(Guid movieId, Guid seanceId)
        {
            var seanceDetails = _mediator.Query(new GetSeanceQuery(movieId, seanceId));
            var model = new BuyTicketViewModel
            {
                MovieId = movieId,
                SeanceId = seanceId,
                SeanceDate = seanceDetails.SeanceDate,
                MovieName = seanceDetails.MovieName
            };

            return View(model);
        }

        [HttpPost("{movieId}/{seanceId}")]
        public IActionResult Index(Guid movieId, Guid seanceId, BuyTicketViewModel model)
        {
            var command = new BuyTicketCommand(new Id<Movie>(movieId), model.SeanceDate, model.Email, model.Quantity);
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                ModelState.PopulateValidation(result.Errors);
                return View(model);
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}