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
            using (var ctx = new ClaimDataContext())
            {
                var stuff = ctx.Conditions.Take(3).OrderBy(x => x.Breed).OrderBy(x => x.Rank).Select(x => new PetInfo
                {
                    ClaimAmount = x.ClaimAmount,
                    Condition = x.DiagnosisCodeDesc,
                    PaidAmount = x.PaidAmount,
                    Rank = x.Rank,
                }).ToList();


                var dataModel = new PetVision.Web.Models.QuotePageOneDataModel
                {
                    PetInfos = stuff,
                    ConditionRanking = stuff.Select(x => x.Condition).ToList(),
                };


                return View(dataModel);
            }
        }
    }
}