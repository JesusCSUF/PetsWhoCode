using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVision.Data.DTO
{
    public class Condition
    {
        public int ClaimCode { get; set; }
        public string DiagnosisCodeDesc { get; set; }
        public string Breed { get; set; }
        public string State { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int Rank { get; set; }
    }
}
