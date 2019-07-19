using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using PetVision.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult UploadImage()/*HttpPostedFileBase file*/
        {
            ViewBag.AlertStatus = "alert-danger";
            ViewBag.FileStatus = "Failed";
            var stream = this.Request.Files[0].InputStream;
            if (stream.Length == 0)
                return View("Index");

            var swriter = new FileStreamResult(stream, MediaTypeNames.Image.Jpeg);

            ViewBag.AlertStatus = "alert-success";
            ViewBag.FileStatus = "Success";

            var imgByteArray = ReadFully(stream);
            MakePredictionRequest(imgByteArray);


//            var aiImageUrl = "https://westus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/041d0e5b-306b-4f6b-9808-4e8f3fc90952/classify/iterations/IterationOne/image";
            //var aiImageUrl = "https://westus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/";
            //var imageinBase64 = Convert.ToBase64String(ReadFully(stream));
//            var predictionKey = "4d81205e0c5541e69003d0d8bc9717a5";
            /*
            var client = new CustomVisionPredictionClient()
            {
                ApiKey = predictionKey,
                Endpoint = aiImageUrl
            };

            var projectId = new Guid("041d0e5b-306b-4f6b-9808-4e8f3fc90952");
            var prediction = client.ClassifyImage(projectId, "IterationOne", stream);
            */
            
//            var client = new RestClient(aiImageUrl);
//            var request = new RestRequest(Method.POST);
//            request.AddHeader("Prediction-Key", "4d81205e0c5541e69003d0d8bc9717a5");
//            request.AddHeader("Content-Type", "application/octet-stream");
            //request.AddJsonBody
//            request.AddBody()

            swriter.FileStream.Position = 0; // reseting the position
            return swriter;
            //return View("Index", new ImageToUpload { File = swriter, FileName = "Test" });
        }

        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static async Task MakePredictionRequest(byte[] byteData)//string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid Prediction-Key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "4d81205e0c5541e69003d0d8bc9717a5");

            // Prediction URL - replace this example URL with your valid Prediction URL.
            string url = "https://westus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/041d0e5b-306b-4f6b-9808-4e8f3fc90952/classify/iterations/IterationOne/image";

            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            //byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = await response.Content.ReadAsStringAsync();
            }
        }

        /*public static void MakePredictionRequest(byte[] byteData)//string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid Prediction-Key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "4d81205e0c5541e69003d0d8bc9717a5");

            // Prediction URL - replace this example URL with your valid Prediction URL.
            string url = "https://westus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/041d0e5b-306b-4f6b-9808-4e8f3fc90952/classify/iterations/IterationOne/image";

            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            //byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = client.PostAsync(url, content);
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = await response.Content.ReadAsStringAsync();
            }
        }*/

        /*private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }*/
    }
}