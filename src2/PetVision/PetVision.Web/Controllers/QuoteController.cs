using PetVision.Data;
using PetVision.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        public ActionResult Index()
        {
            var prediction = (PredictionResult)TempData.Peek("PetPrediction");
            var petImage = (byte[])TempData.Peek("PetImage");

            var petCity = TempData.Peek("PetCity");
            var petState = TempData.Peek("PetState");
            var petZipCode = TempData.Peek("PetZipCode");
            //var predictedBreed = prediction.Predictions.OrderByDescending(x => x.Probability).First(x=>x.TagName != "Canine" && x.TagName != "Feline");

            var predictedBreed = new Prediction
            {
                TagName = "American Curl Shorthair",
            };

            petState = "CA";

            using (var ctx = new ClaimDataContext())
            {
                var claimData = ctx.Conditions.Where(x => x.Breed == predictedBreed.TagName.ToUpper() && x.State == petState.ToString()).OrderBy(x => x.Rank).Take(3).Select(x => new PetCondition
                {
                    ClaimAmount = x.ClaimAmount,
                    Condition = x.DiagnosisCodeDesc,
                    PaidAmount = x.PaidAmount,
                    Rank = x.Rank,
                }).ToList();

                var petInfos = ctx.PetInfos.First(x => x.Breed == predictedBreed.TagName);
                
                
                
                var petInfoOut =  new PetInfo
                {
                    AccordinTo = petInfos.AccordingTo,
                    Issues = petInfos.Issues,
                    Link = petInfos.Link,
                    Originated = petInfos.Originated,
                    Traits = petInfos.Traits,
                };



                var dataModel = new PetVision.Web.Models.QuotePageOneDataModel
                {
                    PetConditions = claimData,
                    ConditionRanking = claimData.Select(x => x.Condition).ToList(),
                    PetImage = petImage,     
                    PredictedBreed = predictedBreed.TagName,
                    PetInfo = petInfoOut
                };

                return View(dataModel);
            }
        }
    }
}