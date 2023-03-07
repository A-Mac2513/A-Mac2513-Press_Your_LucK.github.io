using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Helpers;
using PressYourLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Helpers
{
    public class Filters
    {
        /// <summary>
        /// Used to evaluate which tab/filter the user wants to see the Audits through.
        /// </summary>
        public enum ActiveTab
        {
            All,
            CashIn,
            CashOut,
            Win,
            Lose
        };
        
        /// <summary>
        /// Constructor for the filters, takes in a string representing the data the user wish to see in the 
        /// audits.
        /// </summary>
        /// <param name="filterstring">The tab that the user selected</param>
        public Filters(string filterstring = "all")
        {
            FilterString = filterstring;
        }

        public string FilterString { get; set; }

        /// <summary>
        /// These boolean variables evaluate to see through the filter string which tab the user has chosen.
        /// </summary>
        public bool IsAll => FilterString == "all";
        public bool IsCashIn => FilterString.ToLower() == "cash in";
        public bool IsCashOut => FilterString.ToLower() == "cash out";
        public bool IsWin => FilterString.ToLower() == "win";
        public bool IsLose => FilterString.ToLower() == "lose";

        /// <summary>
        /// Initializinf the enum created above.
        /// </summary>
        public static ActiveTab CurrentTab { get; set; }

        /// <summary>
        /// Depending on the value of the enum above, set all the class strings that will be passed to the Audit/Index view.
        /// </summary>
        /// <returns>A list of ftrings to be inserted into the class value for each nav-link, setting which one is the active one</returns>
        public static List<string> GetActiveTab ()
        {
            List<string> activeTab = new List<string>()
            {
                "","","","",""
            };
            switch (CurrentTab)
            {
                case ActiveTab.All:
                    activeTab[0] = "nav-link active";
                    activeTab[1] = "nav-link";
                    activeTab[2] = "nav-link";
                    activeTab[3] = "nav-link";
                    activeTab[4] = "nav-link";
                    break;
                case ActiveTab.CashIn:
                    activeTab[0] = "nav-link";
                    activeTab[1] = "nav-link active";
                    activeTab[2] = "nav-link";
                    activeTab[3] = "nav-link";
                    activeTab[4] = "nav-link";
                    break;
                case ActiveTab.CashOut:
                    activeTab[0] = "nav-link";
                    activeTab[1] = "nav-link";
                    activeTab[2] = "nav-link active";
                    activeTab[3] = "nav-link";
                    activeTab[4] = "nav-link";
                    break;
                case ActiveTab.Lose:
                    activeTab[0] = "nav-link";
                    activeTab[1] = "nav-link";
                    activeTab[2] = "nav-link";
                    activeTab[3] = "nav-link active";
                    activeTab[4] = "nav-link";
                    break;
                case ActiveTab.Win:
                    activeTab[0] = "nav-link";
                    activeTab[1] = "nav-link";
                    activeTab[2] = "nav-link";
                    activeTab[3] = "nav-link";
                    activeTab[4] = "nav-link active";
                    break;
              
                default:
                    break;
            }
            return activeTab;
        }
    }
}

