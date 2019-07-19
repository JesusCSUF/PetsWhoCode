using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class QuotePageOneDataModel
    {
        public IEnumerable<PetCondition> PetConditions { get; set; }
        public List<string> ConditionRanking { get; set; }
        public string PredictedBreed { get; set; }
        public byte[] PetImage { get; set; }

        public PetInfo PetInfo { get; set; }

        public string ZipCode { get; set; }
        public string State { get; set; }
        public PetPricing Pet { get; set; }
        public Dictionary<string,PricingObject> Pricings { get; set; }
    }
}