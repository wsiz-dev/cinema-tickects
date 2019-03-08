using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinemaTickets.Domain;
using Microsoft.AspNetCore.Mvc;
using CinemaTickets.UI.Models;

namespace CinemaTickets.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly Messages _messages;

        public HomeController(Messages messages)
        {
            _messages = messages;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
