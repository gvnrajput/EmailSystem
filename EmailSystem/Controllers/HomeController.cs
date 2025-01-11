using EmailSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace EmailSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext appDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDb)
        {
            _logger = logger;
            appDbContext = appDb;
        }

        public IActionResult Index()
        {
            // Getting Emails List for Inbox

            int currentLoggedInUserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            List<VM_EmailDetails> emailList = new List<VM_EmailDetails>();
            List<EmailDetails> emailDetails = appDbContext.EmailDetails.Where(x => x.To == currentLoggedInUserId).ToList();
            List<Users> users = appDbContext.Users.ToList();
            
            foreach (EmailDetails item in emailDetails)
            {
                VM_EmailDetails obj = new VM_EmailDetails
                {
                    Id= item.Id,
                    From = users.Where(x=>x.UserId== item.From).FirstOrDefault()?.UserName,
                    Subject = item.Subject,
                    Body = item.Body,
                    IsAttachment = item.IsAttachment,
                    SentDateTime = item.SentDateTime,
                };
                emailList.Add(obj);
            }
            
            return View(emailList);
        }
        public IActionResult ComposeEmail()
        {
            return View(new VM_EmailDetails());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
