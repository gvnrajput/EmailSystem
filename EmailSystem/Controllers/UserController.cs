using Microsoft.AspNetCore.Mvc;

namespace EmailSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
