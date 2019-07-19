using Newtonsoft.Json;
using PetVision.Data;
using PetVision.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                var quote = CreateQuote(new QuoteRequest
                {
                    SourceSystemId = newQec,
                    Owner = new Owner
                    {
                        ZipCode = "92883",
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
                            Species = Species.Canine,
                            DateOfBirth = "10/MAR/2017",
                            ProductId = "VBW25090",
                            Breed = "9999"
                        }
                    }
                });

                var dataModel = new PetVision.Web.Models.QuotePageOneDataModel
                {
                    PetInfos = stuff,
                    ConditionRanking = stuff.Select(x => x.Condition).ToList(),
                    IpAdress = ipAddress,
                };

                return View(dataModel);
            }
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
    }
}