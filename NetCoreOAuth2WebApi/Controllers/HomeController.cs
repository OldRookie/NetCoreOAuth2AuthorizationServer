using Microsoft.AspNetCore.Mvc;

namespace NetCoreOAuth2WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}