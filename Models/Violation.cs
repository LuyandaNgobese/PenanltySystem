using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PenanltySystem.Models
{
    public class Violation
    {
        [Key]
        public int ViolationCode { get; set; }
        public string ViolationName { get; set; }
        public double ViolationCost { get; set; }
    }
}