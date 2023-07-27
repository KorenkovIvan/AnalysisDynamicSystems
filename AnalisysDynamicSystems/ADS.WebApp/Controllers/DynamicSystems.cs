using Microsoft.AspNetCore.Mvc;

namespace ADS.WebApp.Controllers
{
    public class DynamicSystems : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
