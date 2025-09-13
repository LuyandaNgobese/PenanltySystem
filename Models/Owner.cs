using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PenanltySystem.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int OwnerAge { get;set; }
        public int OwnerPoints { get; set; }


    }
}