using EmailSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmailSystem.Controllers
{

    public class LoginController : Controller
    {
        public AppDbContext appDbContext;
        public LoginController(AppDbContext _AppDbContext)
        {
            appDbContext = _AppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users obj)
        {
            List<Users> users = appDbContext.Users.ToList();
            Users usr = users.Where(x => x.UserName.ToLower() == obj.UserName.ToLower() && x.password == obj.password).FirstOrDefault();
            if (usr != null)
            {
                HttpContext.Session.SetString("Username", usr.UserName); // Storing a string
                HttpContext.Session.SetInt32("UserId", usr.UserId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
