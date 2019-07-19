using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class PetInfo
    {
        public string Condition { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal PaidAmount { get; set; }
    }
}