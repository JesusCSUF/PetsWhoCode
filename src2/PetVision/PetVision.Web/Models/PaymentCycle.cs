using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetVision.Web.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentCycle
    {
        Monthly,
        Annual,
        Payroll
    }
}