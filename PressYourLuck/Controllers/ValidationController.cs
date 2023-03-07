using Microsoft.AspNetCore.Mvc;
using PressYourLuck.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult CheckCurrentBet(double CurrentBet)
        {
            string msg = "";
            double currentBalance = CoinsHelper.GetTotalCoins(HttpContext);
            if (CurrentBet <= 0)
            {
                msg = $"The bet {CurrentBet.ToString("C2")} is not a valid wager. Please enter a bet that's greater than $0.00";
                return Json(msg);
            }
            if (CurrentBet > currentBalance)
            {
                msg = $"The bet {CurrentBet.ToString("C2")} is greater than your current balance of {currentBalance.ToString("C2")}. " +
                    $"Please enter an amount that is not more than your balance.";
                return Json(msg);
            }
            return Json(true);
        }
    }
}
