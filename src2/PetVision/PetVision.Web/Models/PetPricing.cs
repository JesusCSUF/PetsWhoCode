namespace PetVision.Web.Models
{
    public class PetPricing
    {
        public Pet Pet { get; set; }
        public ProductSpecification ProductSpecification { get; set; }
        public ProductPricingBreakdown Pricing { get; set; }
    }
}