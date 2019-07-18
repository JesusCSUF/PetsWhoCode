using System.Web.Mvc;

namespace PetVision.Web.Controllers
{
    public class AboutController : PetVisionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}