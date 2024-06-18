using Microsoft.AspNetCore.Mvc;

namespace kurikulum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
