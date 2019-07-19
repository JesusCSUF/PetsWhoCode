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
            var result = prediction.Predictions.OrderByDescending(x => x.Probability).First(x=>x.TagName != "Canine" && x.TagName != "Feline");

            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            
            ipAddress = "64.209.128.78";

            using (var ctx = new ClaimDataContext())
            {
                var stuff = ctx.Conditions.Take(3).OrderBy(x => x.Breed).OrderBy(x => x.Rank).Select(x => new PetInfo
                {
                    ClaimAmount = x.ClaimAmount,
                    Condition = x.DiagnosisCodeDesc,
                    PaidAmount = x.PaidAmount,
                    Rank = x.Rank,
                }).ToList();


                var stuff2 = ctx.PetInfos.Take(3).ToList();



                var dataModel = new PetVision.Web.Models.QuotePageOneDataModel
                {
                    PetInfos = stuff,
                    ConditionRanking = stuff.Select(x => x.Condition).ToList(),
                    IpAdress = ipAddress,
                };

                return View(dataModel);
            }
        }
    }
}