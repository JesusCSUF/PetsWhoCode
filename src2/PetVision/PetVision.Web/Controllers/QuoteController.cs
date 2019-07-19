using Newtonsoft.Json;
using PetVision.Data;
using PetVision.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace PetVision.Web.Controllers
{
    public class QuoteController : Controller
    {
        static readonly string createQuoteUrl = "https://orchf.petinsurance.com/api/Quotes";
        static HashSet<string> SuccessfulStatuses { get { return new HashSet<string> { "200", "201" }; } }
        string newQec = "110000000000001";

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

               var pricingBreakDown = new Dictionary<string, PricingObject>();

                Species speice = Species.Canine;
                if(petInfos.SpecieCode == "F")
                {
                    speice = Species.Feline;
                }
                var quote = GetQuote("10/MAR/2019", petZipCode.ToString(), petInfos.BreedCode.ToString(), speice);
                var pricingObject = new PricingObject
                {
                    Annual = quote.Quote.TotalPrice.First(x => x.PaymentCycle == PaymentCycle.Annual).AnnualPremium,
                    Monthly = quote.Quote.TotalPrice.First(x => x.PaymentCycle == PaymentCycle.Monthly).PeriodPremium,
                };

                var pricingObject2 = new PricingObject {
                    Annual = pricingObject.Annual - 200,
                    Monthly = pricingObject.Monthly - 50,
                };

                var pricingObject3 = new PricingObject
                {
                    Annual = pricingObject.Annual - 150,
                    Monthly = pricingObject.Monthly - 40,
                };


                pricingBreakDown.Add("1 - 11 Month Old", pricingObject);
                pricingBreakDown.Add("1 Yr Old", pricingObject2);
                pricingBreakDown.Add("2 Yr Old", pricingObject3);
               


                var dataModel = new PetVision.Web.Models.QuotePageOneDataModel
                {
                    PetConditions = claimData,
                    ConditionRanking = claimData.Select(x => x.Condition).ToList(),
                    PetImage = petImage,
                    PredictedBreed = predictedBreed.TagName,
                    PetInfo = petInfoOut,
                    Pet = quote.Quote.Pets.First(),
                    Pricings = pricingBreakDown,
                    State = petState.ToString(),
                    ZipCode = petState.ToString(),
                };

                return View(dataModel);
            }
        }

        private PostQuoteResponse GetQuote(string birthDate, string zipCode, string breed, Species species)
        {
            var quote = CreateQuote(new QuoteRequest
            {
                SourceSystemId = newQec,
                Owner = new Owner
                {
                    ZipCode = zipCode,
                    Email = "TestHack01@test.com",
                    Group = new Group
                    {
                        NonPayrollId = "N241"
                    }
                },
                Pets = new HashSet<Pet>
                    {
                        new Pet
                        {
                            Name = "Hackapet",
                            Species = species,
                            //DateOfBirth = "10/MAR/2018",
                            DateOfBirth = birthDate,
                            ProductId = "VBW25090",
                            Breed = breed
                        }
                    }
            });
            return quote;
        }

        private static PostQuoteResponse CreateQuote(QuoteRequest quoteRequest)
        {
            //Avoiding TLS issues with our server
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var client = new RestClient(createQuoteUrl);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(quoteRequest);

            var response = client.Execute(request);
            var deserialized = JsonConvert.DeserializeObject<PostQuoteResponse>(response.Content);
            if (SuccessfulStatuses.Contains(deserialized?.StandardMessage?.Code))
            {
                return deserialized;
            }

            return null;
        }

        //[HttpPost]
        public ActionResult Billing()
        {
            return View("Billing");
        }
    }
}