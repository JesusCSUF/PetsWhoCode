using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class PredictionResult
    {
        public Guid Id { get; set; }
        public Guid Project { get; set; }
        public Guid Iteration { get; set; }
        public List<Prediction> Predictions { get; set; }
    }

    public class Prediction
    {
        public decimal Probability { get; set; }
        public Guid TagId { get; set; }
        public string TagName { get; set; }
    }
}