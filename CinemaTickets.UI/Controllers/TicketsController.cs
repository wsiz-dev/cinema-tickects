using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Query;
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

        [HttpGet("{movieId?}/{seanceId?}")]
        public IActionResult Index(Guid movieId, Guid seanceId)
        {
            var seanceDetails = _mediator.Query(new GetSeanceQuery(movieId, seanceId));
            return View();
        }
    }
}