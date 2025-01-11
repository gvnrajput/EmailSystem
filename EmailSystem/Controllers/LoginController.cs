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
            Users usr = users.Where(x=> x.UserName == obj.UserName && x.password==obj.password).FirstOrDefault();
            if (usr!=null)
            {
                RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}
