using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetVision.Web.Models
{
    public class Disclosure
    {
        public DisclosureType DisclosureType { get; set; }

        public decimal Amount { get; set; }

        public string DisclosureDescription { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DisclosureType
    {
        Discount,
        AnnualFee,
        MonthlyFee,
        FirstInstallment,
        Surcharge,
    }
}