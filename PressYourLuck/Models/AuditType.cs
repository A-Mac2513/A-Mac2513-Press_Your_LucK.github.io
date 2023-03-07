using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class AuditType
    {
        [Key]
        public string AuditTypeId { get; set; }
               
        public string Name { get; set; }
    }
}
