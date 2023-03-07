using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet()]
        public IActionResult CreatePlayer()
        {
            ViewBag.Action = "Create Player";
            return View();
        }

        [HttpPost()]
        public IActionResult CreatePlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                var session = HttpContext;
                CoinsHelper.SaveTotalCoins(session, player.CoinBalance);
                GameHelper.SavePlayerName(session, player.PlayerName);
                return RedirectToAction("CashIn", "Audit", player);
            }
            else
            {
                ViewBag.Action = "Create Player";
                ModelState.AddModelError("", "Please correct all errors in highlighted fields");
                return View(player);
            }
        }

        [HttpGet()]
        public IActionResult CashOut()
        {
            if (string.IsNullOrEmpty(GameHelper.GetPlayerName(HttpContext)))
                return RedirectToAction("CreatePlayer", "Player");
            double total = GameHelper.TakeCoins(HttpContext);
            TempData["message"] = $"{GameHelper.GetPlayerName(HttpContext)}, you cashed out with {total.ToString("C2")}";

            return RedirectToAction("CashOut", "Audit");
        }

        [HttpGet()]
        public IActionResult TakeCoins()
        {
            double total = GameHelper.TakeCoins(HttpContext);

            TempData["message"] = $"BIG WINNER!! You cashed out " +
                $"{CoinsHelper.GetCurrentBet(HttpContext).ToString("C2")}, " +
                $"now your balance is {total.ToString("C2") } ! " +
                $"\nCare to Press Your Luck again?";

            GameHelper.ClearCurrentGame(HttpContext);

            List<Tile> newGame = GameHelper.GenerateNewGame();
            GameHelper.SaveCurrentGame(HttpContext, newGame);
            return RedirectToAction("Index", "Home");
        }
    }
}
