using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Models
{
    public class ImageToUpload
    {
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please upload or take a picture of your pet.")]
        public HttpPostedFileBase AttachedFile { get; set; }
    }
}