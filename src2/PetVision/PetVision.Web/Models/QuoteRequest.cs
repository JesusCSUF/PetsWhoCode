using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class QuoteRequest
    {
        public QuoteRequest()
        {
            Pets = new HashSet<Pet>();
        }

        public string SourceSystemId { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}