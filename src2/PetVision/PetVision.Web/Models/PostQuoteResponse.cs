using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PetVision.Web.Models
{
    public class PostQuoteResponse : ISerializable 
    {
        public StandardMessage StandardMessage { get; set; }
        public QuoteResponse Quote { get; set; }
        public PostQuoteResponse()
        {
            StandardMessage = new StandardMessage { Code = "200" };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}