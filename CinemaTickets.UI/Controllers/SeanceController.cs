using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Query;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class SeanceController : Controller
    {
        private readonly IMediator _mediator;

        public SeanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            var movie = _mediator.Query(new GetMovieQuery(id));
            return View(movie);
        }

        [HttpGet("{movieId?}/{seanceId?}")]
        public IActionResult BuyTicket(Guid movieId, Guid seanceId)
        {
            var seanceDetails = _mediator.Query(new GetSeanceQuery(movieId, seanceId));
            return View();
        }
    }
}