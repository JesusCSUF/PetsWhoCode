using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class QuotePageOneDataModel
    {
        public IEnumerable<PetInfo> PetInfos { get; set; }
    }
}