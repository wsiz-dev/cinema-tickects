using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaTickets.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly Messages _messages;

        public MovieController(Messages messages)
        {
            _messages = messages;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}