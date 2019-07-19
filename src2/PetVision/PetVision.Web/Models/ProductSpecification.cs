using System.Collections.Generic;

namespace PetVision.Web.Models
{
    public class ProductSpecification
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public PaymentCycle PaymentType { get; set; }

        public IEnumerable<CoverageType> Coverages { get; set; }

        public decimal BaseRate { get; set; }

        public decimal Rate { get; set; }

        public decimal Discount { get; set; }

        public decimal Deductible { get; set; }

        public decimal MaxBenefit { get; set; }

        public decimal PercentBack { get; set; }

        public IEnumerable<DisclaimerResponse> Disclaimer { get; set; }

        public string StaticPDF { get; set; }
    }
}