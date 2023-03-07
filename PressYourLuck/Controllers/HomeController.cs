using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("playerName"))
                return RedirectToAction("CreatePlayer", "Player");
            else
            {
                List<Tile> newGame = GameHelper.GenerateNewGame();
                GameHelper.SaveCurrentGame(HttpContext, newGame);
                return View();
            }
        }     
    }
}
