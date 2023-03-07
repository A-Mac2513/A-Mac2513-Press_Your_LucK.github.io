using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PressYourLuck.Controllers
{
    public class GameController : Controller
    {        
        [HttpGet()]
        public IActionResult Index()
        {
            List<Tile> currentGame = GameHelper.GetCurrentGame(HttpContext);
            if (currentGame.Count() <= 0)
            {
                List<Tile> tileList = GameHelper.GenerateNewGame();
                ViewBag.CBet = CoinsHelper.GetCurrentBet(HttpContext);
                GameHelper.SaveCurrentGame(HttpContext, tileList);
                CurrentGameViewModel model = new CurrentGameViewModel()
                {
                    CurrentTiles = tileList,
                    CurrentBetAmnt = CoinsHelper.GetCurrentBet(HttpContext)
                };
                return View(model);
            }
            else
            {
                ViewBag.CBet = CoinsHelper.GetCurrentBet(HttpContext);

                CurrentGameViewModel model = new CurrentGameViewModel()
                {
                    CurrentTiles = currentGame,
                    CurrentBetAmnt = CoinsHelper.GetCurrentBet(HttpContext)
                };
                return View(model);
            }
        }

        [HttpGet()]
        public IActionResult FlipCard(int id)
        {
            List<Tile> currentGame = GameHelper.GetCurrentGame(HttpContext);
            double multiplier = double.Parse(currentGame[id].Value); 
            GameHelper.PickTileAndUpdateGame(HttpContext, id, currentGame, multiplier);
            double bet = CoinsHelper.GetCurrentBet(HttpContext);
            if (bet == 0.00)
            {                
                TempData["message"] = "OH NO! It's a BUST.  Try Again!";
                return RedirectToAction("Lose", "Audit");
            }
            else
                TempData["message"] = $"Congrats! You found a {multiplier} multiplier!" +
                    $" All remaining mutlipliers have DOUBLED! Will you Press Your Luck?";

            double total = CoinsHelper.GetTotalCoins(HttpContext);
            if (total <= 0.00)
            {
                TempData["message"] = "You have lose ALL your coins! Please enter more to continue.";
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Win", "Audit");            
        }

        [HttpPost()]
        public IActionResult Index (PlayerBets cb)
        {
            if (ModelState.IsValid)
            {
                var session = HttpContext;
                double currentBet = cb.CurrentBet;
                double totalCoins = CoinsHelper.GetTotalCoins(session);
                totalCoins -= currentBet;
                CoinsHelper.SaveTotalCoins(session, totalCoins);
                CoinsHelper.SaveOriginalBet(session, currentBet);
                CoinsHelper.SaveCurrentBet(session, currentBet);
                return RedirectToAction("Index", "Game");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors in highlighted fields");
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
