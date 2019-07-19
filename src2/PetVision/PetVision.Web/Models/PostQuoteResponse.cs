using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetVision.Web.Models
{
    public class PostQuoteResponse
    {
        public StandardMessage StandardMessage { get; set; }
        public QuoteResponse Quote { get; set; }
        public PostQuoteResponse()
        {
            StandardMessage = new StandardMessage { Code = "200" };
        }
    }
}