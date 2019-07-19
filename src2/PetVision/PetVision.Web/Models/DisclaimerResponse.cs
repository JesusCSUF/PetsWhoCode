using System.Collections.Generic;

namespace PetVision.Web.Models
{
    public class DisclaimerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<DisclaimerItem> Items { get; set; }
    }
}