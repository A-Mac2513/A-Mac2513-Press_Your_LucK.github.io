using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class Audit
    {
        [Key]
        public int AuditId { get; set; }

        [Required]
        [RegularExpression("(?i)^[a-z0-9]+$", ErrorMessage = "User Name may not contain spaces or special characters.")]
        public string PlayerName { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Remote("CheckCurrentBet", "Validation")]
        public double Amount { get; set; }

        [Required]
        public string AuditTypeId { get; set; }
        public AuditType auditTypes { get; set; }
    }
}
