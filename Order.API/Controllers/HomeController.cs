using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
