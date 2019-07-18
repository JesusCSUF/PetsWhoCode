using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace PetVision.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PetVisionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}