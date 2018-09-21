using Microsoft.AspNetCore.Mvc;

namespace NetCoreOAuth2AuthorizationServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}