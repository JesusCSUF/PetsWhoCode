using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetVision.Web.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public Species? Species { get; set; }
        public string DateOfBirth { get; set; }
        public string ProductId { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Species
    {
        Canine,
        Feline,
        Avian,
        Exotic,
        Reptile
    }
}