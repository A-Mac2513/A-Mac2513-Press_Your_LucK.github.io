using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class Player
    {
        private string _playerName;
        private double _coinBalance;

        [Required]
        [RegularExpression("(?i)^[a-z0-9]+$", ErrorMessage = "User Name may not contain spaces or special characters.")]
        public string PlayerName { get => _playerName; set => _playerName = value; }

        [Required]
        [Range (1.00, 10000.00, ErrorMessage = "The starting balance must be between $1.00 and $10,000.00")]
        public double CoinBalance { get => _coinBalance; set => _coinBalance = value; }  
    }
}
