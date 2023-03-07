using Microsoft.AspNetCore.Http;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PressYourLuck.Helpers
{
    public static class GameHelper
    {
        /// <summary>
        /// Turns the Cookie to a persistent cookie, bys setting the expiry date to 30 days from the day its created
        /// </summary>
        private static CookieOptions options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        };

        /// <summary>
        /// Generates tiles, with a random multiplier value, and index for teh tile and sets its visible boolean to false.
        /// </summary>
        /// <returns>A list of tiles to be given tot he Game/Index view</returns>
        public static List<Tile> GenerateNewGame()
        {
            var tileList = new List<Tile>();
            Random r = new Random();
            for (int i = 0; i < 12; i++)
            {
                double randomValue = 0;
                if (r.Next(1, 4) != 1)
                {
                    randomValue = (r.NextDouble() + 0.5) * 2;
                }

                var tile = new Tile()
                {
                    TileIndex = i,
                    Visible = false,
                    Value = randomValue.ToString("N2")
                };

                tileList.Add(tile);
            }
            return tileList;
        }
       
        /// <summary>
        /// Checks to see if the tile-list (aka the current game) has been saved.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns> If not, it returns an empty list, else the List that has been Serialized is de-serialized and saved to a list</returns>
        public static List<Tile> GetCurrentGame(HttpContext httpContext)
        {
            List<Tile> tiles = new List<Tile>();
            string value = httpContext.Session.GetString("tile-list");
            if (string.IsNullOrEmpty(value))
            {              
                return tiles;
            }
            else
            {
                tiles = JsonConvert.DeserializeObject<List<Tile>>(value);                 
                return tiles;
            }
        }

        /// <summary>
        /// Takes in the current list of tiles which is the current game and Serializes the list to a string that can be sved to a session
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tiles"></param>
        public static void SaveCurrentGame(HttpContext context, List<Tile> tiles)
        {
            context.Session.SetString("tile-list", JsonConvert.SerializeObject(tiles));
        }
       
        /// <summary>
        /// This is the main game logic for Press Your Luck.  It flips all the cards over by setting all the tiles Visible bool to true
        /// If the user has selected a card with a 0.00 multiplier.
        /// If the user didn't pick a 0.00 mulitplier the card is found using id or its Index value, it is flipped over, the mutliplier is applied
        /// to the current bet from the session data. All other cards multiplier are doubled. 
        /// The new list of tiles is saved to the current game session and passed back.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id">The tiles Index value passed from the button the user picked</param>
        /// <param name="tiles"> the list of the current game as it was before the user picked </param>
        /// <param name="multi">the tile value of the card the user picked</param>
        public static void PickTileAndUpdateGame(HttpContext context, int id, List<Tile> tiles, double multi )
        {            
            double oldBet = CoinsHelper.GetCurrentBet(context);
            double newBet = oldBet * multi;
            CoinsHelper.SaveCurrentBet(context, newBet); 
            if (multi == 0.00)
            {
                for (int index = 0; index < tiles.Count; index++)
                {
                    tiles[index].Visible = true;
                }
                SaveCurrentGame(context, tiles);
            }
            else
            {
                tiles[id].Visible = true;
                for (int index = 0; index < tiles.Count; index++)
                {
                    if (tiles[index] != tiles[id])
                    {
                        tiles[index].Value = (double.Parse(tiles[index].Value)*2).ToString("N2");
                    }
                }
                SaveCurrentGame(context, tiles);
            }            
        }

        /// <summary>
        /// This method is called if the user selects take the coins or cash out. 
        /// Removes all the session data. some times the cookies don't need removed, so that's why
        /// its not included in here.
        /// </summary>
        /// <param name="context"></param>
        public static void ClearCurrentGame(HttpContext context)
        {
            context.Session.Remove("tile-list");
            context.Session.Remove("original-bet");
            context.Session.Remove("current-bet");
        }

        public static void SavePlayerName(HttpContext context, string name)
        {
            context.Response.Cookies.Append("playerName", name, options);
        }

        public static string GetPlayerName (HttpContext context)
        {
            return context.Request.Cookies["playerName"];
        }

        /// <summary>
        /// When the user selects "Take the Coins" this gets the total coins, the current bet, which has
        /// been updated to include the latest win.
        /// Then it adds the current current bet to the total coins and returns the new total to the cotroller.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static double TakeCoins (HttpContext context)
        {
            double totalCoins = CoinsHelper.GetTotalCoins(context);
            double currentBet = CoinsHelper.GetCurrentBet(context);
            totalCoins += currentBet;
            CoinsHelper.SaveTotalCoins(context, totalCoins);
            return totalCoins;
        }
    }
}
