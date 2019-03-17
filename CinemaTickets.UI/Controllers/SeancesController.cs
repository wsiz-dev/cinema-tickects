using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Query;
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
    }
}