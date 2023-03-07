using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Controllers
{
    public class AuditController : Controller
    {
/*        private AuditContext _auditContext;
*/        public AuditController (/*AuditContext ctx*/)
        {
/*            this._auditContext = ctx;
*/        }

        [HttpGet()]
        public IActionResult CashIn (Player player)
        {
            Audit record = new Audit()
            {
                PlayerName = player.PlayerName,
                CreatedDate = DateTime.Now,
                Amount = player.CoinBalance,
                AuditTypeId = "ci"
            };
            /*_auditContext.Audits.Add(record);
            _auditContext.SaveChanges();*/
            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        public IActionResult CashOut()
        {
            Audit record = new Audit()
            {
                PlayerName = GameHelper.GetPlayerName(HttpContext),
                CreatedDate = DateTime.Now,
                Amount = CoinsHelper.GetTotalCoins(HttpContext),
                AuditTypeId = "co"
            };

            /*_auditContext.Audits.Update(record);
            _auditContext.SaveChanges();*/

            GameHelper.ClearCurrentGame(HttpContext);
            HttpContext.Response.Cookies.Delete("playerName");
            HttpContext.Response.Cookies.Delete("total-coins");           

            return RedirectToAction("CreatePlayer", "Player");
        }

        [HttpGet()]
        public IActionResult Win()
        {
            double originalBet = CoinsHelper.GetOriginalBet(HttpContext);
            double currentCoins = CoinsHelper.GetCurrentBet(HttpContext);
            double winnings = currentCoins - originalBet;

            Audit record = new Audit()
            {
                PlayerName = GameHelper.GetPlayerName(HttpContext),
                CreatedDate = DateTime.Now,
                Amount = winnings,
                AuditTypeId = "w"
            };

            /*_auditContext.Audits.Update(record);
            _auditContext.SaveChanges();*/

            return RedirectToAction("Index", "Game");
        }

        [HttpGet()]
        public IActionResult Lose()
        {
            Audit record = new Audit()
            {
                PlayerName = GameHelper.GetPlayerName(HttpContext),
                CreatedDate = DateTime.Now,
                Amount = CoinsHelper.GetOriginalBet(HttpContext),
                AuditTypeId = "l"
            };

           /* _auditContext.Audits.Update(record);
            _auditContext.SaveChanges();*/

            return RedirectToAction("Index", "Game");
        }

       /* [HttpGet()]
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("filter"))
                HttpContext.Session.SetString("filter", "all");
            else
                HttpContext.Session.SetString("filter", HttpContext.Request.Query["query"]);

            string tab = HttpContext.Session.GetString("filter");

            var model = new List<Audit>();
            var filter = new Filters(tab);
          
            if (filter.IsAll)
            {
                model = _auditContext.Audits.Include(a => a.auditTypes)                
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
                Filters.CurrentTab = Filters.ActiveTab.All;
            }
            else if (filter.IsCashIn)
            {
                model = _auditContext.Audits.Include(a => a.auditTypes)
                .Where(a => a.auditTypes.Name == filter.FilterString)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
                Filters.CurrentTab = Filters.ActiveTab.CashIn;
            }
            else if (filter.IsCashOut)
            {
                model = _auditContext.Audits.Include(a => a.auditTypes)
                .Where(a => a.auditTypes.Name == filter.FilterString)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
                Filters.CurrentTab = Filters.ActiveTab.CashOut;
            }
            else if (filter.IsWin)
            {
                model = _auditContext.Audits.Include(a => a.auditTypes)
                .Where(a => a.auditTypes.Name == filter.FilterString)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
                Filters.CurrentTab = Filters.ActiveTab.Win;
            }
            else if (filter.IsLose)
            {
                model = _auditContext.Audits.Include(a => a.auditTypes)
                .Where(a => a.auditTypes.Name == filter.FilterString)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
                Filters.CurrentTab = Filters.ActiveTab.Lose;
            }

            List<string> currentTab = Filters.GetActiveTab();

            ViewBag.All = currentTab[0];
            ViewBag.CashIn = currentTab[1];
            ViewBag.CashOut = currentTab[2];
            ViewBag.Lose = currentTab[3];
            ViewBag.Win = currentTab[4];

            return View(model);
        }*/
    }
}
