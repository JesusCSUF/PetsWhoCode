using System.Collections.Generic;

namespace PetVision.Web.Models
{
    public class QuoteResponse
    {
        public QuoteResponse()
        {
            _paymentFrequency = 26;
        }

        public QuoteResponse(int paymentFrequency = 26)
        {
            Pets = new HashSet<PetPricing>();
            Owner = new Owner();
            _paymentFrequency = paymentFrequency;
        }

        public string QuoteId { get; set; }

        public IEnumerable<Pricing> TotalPrice { get; set; }

        public Owner Owner { get; set; }

        public HashSet<PetPricing> Pets { get; set; }

        private int _paymentFrequency;
    }
}