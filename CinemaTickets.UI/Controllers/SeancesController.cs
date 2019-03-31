using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Command.Seances;
using CinemaTickets.Domain.Query.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class SeancesController : Controller
    {
        private readonly IMediator _mediator;

        public SeancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            var movie = _mediator.Query(new GetMovieQuery(id));
            return View(movie);
        }

        [HttpGet("{movieId}")]
        public IActionResult Add(Guid movieId)
        {
            var command = new RegisterSeanceCommand
            {
                MovieId = movieId,
                SeanceDate = DateTime.UtcNow
            };

            return View(command);
        }

        [HttpPost("{movieId}")]
        public IActionResult Add(Guid movieId, RegisterSeanceCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                ModelState.PopulateValidation(result.Errors);
                return View(command);
            }

            return RedirectToAction("Index", new { id = movieId });
        }
    }
}