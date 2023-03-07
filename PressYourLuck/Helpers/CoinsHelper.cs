using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PressYourLuck.Helpers
{
    public static class CoinsHelper
    {
        /// <summary>
        /// Turns the Cookie to a persistent cookie, bys setting the expiry date to 30 days from the day its created
        /// </summary>
        private static CookieOptions options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        };

        /// <summary>
        /// Take the bet entered by user or the current bet after flipping a card, sets it the session.
        /// </summary>
        /// <param name="httpContext">Context passed from controller</param>
        /// <param name="bet">The bet from user that is taken by controller then passed along to this method, 
        /// or the bet after the player flips a card and finds a multiplier</param>
        // Save the current bet in Session 
        public static void SaveCurrentBet(HttpContext httpContext, double bet)
        {
            httpContext.Session.SetString("current-bet", bet.ToString("N2"));
        }

        //Return the current bet stored in session
        public static double GetCurrentBet(HttpContext httpContext)
        {
            if (string.IsNullOrEmpty(httpContext.Session.GetString("current-bet")))
            {
                return 0.00;
            }
            else
            {
                double currentBet = double.Parse(httpContext.Session.GetString("current-bet"));
                return currentBet;
            }
        }

        /// <summary>
        /// Keeps the original bet entered in the Home/Index view, to be used for various calculations
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="bet">The is the bet entered by user at the Home/Index view</param>
        //Save the original bet into session
        public static void SaveOriginalBet(HttpContext httpContext, double bet)
        {
            httpContext.Session.SetString("original-bet", bet.ToString("N2"));
        }

        //Get the original bet from session
        public static double GetOriginalBet(HttpContext context)
        {
            double originalBet = double.Parse(context.Session.GetString("original-bet"));
            return originalBet;
        }

        /// <summary>
        /// Used when the player enters their name and initial amount of coins in the Player/CreatePlayer view
        /// Used whenever the player "Cash's Out" or "Takes the Coins".
        /// </summary>
        /// <param name="context"></param>
        /// <param name="amount"> This is either the amount enterd in Player/CreatePlayer view, or the current-bet 
        /// added to the total coins.</param>
        //Save the players total number of coins into a cookie.  
        public static void SaveTotalCoins(HttpContext context, double amount)
        {
            context.Response.Cookies.Append("total-coins", amount.ToString("N2"), options);
        }

        //Get the players total number of coins from a cookie.
        public static double GetTotalCoins(HttpContext context)
        {
            double total = double.Parse(context.Request.Cookies["total-coins"]);
            return total;
        }
    }
}
