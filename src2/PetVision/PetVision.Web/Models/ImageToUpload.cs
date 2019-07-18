using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Models
{
    public class ImageToUpload : HttpPostedFileBase
    {
        [DataType(DataType.Upload)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please upload an image")]
        public string FileName { get; set; }

        public FileStreamResult File { get; set; }
    }
}