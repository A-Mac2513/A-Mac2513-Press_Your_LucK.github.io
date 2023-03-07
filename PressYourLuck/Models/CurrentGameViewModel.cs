using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class CurrentGameViewModel
    {
        public List<Tile> CurrentTiles {get; set;}
        public double CurrentBetAmnt { get; set; }
    }
}
