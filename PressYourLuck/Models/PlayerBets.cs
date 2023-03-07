using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class PlayerBets
    {
        private double _currentBet;

        [Required]
        [Remote("CheckCurrentBet", "Validation")]
        public double CurrentBet { get => _currentBet; set => _currentBet = value; }       
    }
}
