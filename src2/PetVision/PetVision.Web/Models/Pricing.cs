using System.Collections.Generic;

namespace PetVision.Web.Models
{
    public class Pricing
    {
        public Pricing()
        {
            Disclosures = new HashSet<Disclosure>();
        }

        public PaymentCycle PaymentCycle { get; set; }

        public decimal AnnualPremium { get; set; }

        public decimal PeriodPremium { get; set; }

        public ICollection<Disclosure> Disclosures { get; set; }
    }
}