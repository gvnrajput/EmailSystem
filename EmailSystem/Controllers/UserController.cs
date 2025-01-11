using EmailSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailSystem.Controllers
{
    public class UserController : Controller
    {
        public AppDbContext appDbContext;
        public UserController(AppDbContext _AppDbContext)
        {
            appDbContext = _AppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users objUsers)
        {
            try
            {
                objUsers.createdOn = DateTime.Now;
                appDbContext.Users.Add(objUsers);
                RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {

            }
            
            return View();
        }
    }
}
