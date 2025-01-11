using EmailSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailSystem.Controllers
{
    public class SendEmailController : Controller
    {
        private readonly AppDbContext appDbContext;

        public SendEmailController(AppDbContext appDb)
        {
            appDbContext = appDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(VM_EmailDetails emailDetails)
        {
            if (ModelState.IsValid)
            {
                List<Users> users = appDbContext.Users.ToList();
                Users toUser = users.Where(x => x.UserName.ToLower() == emailDetails.To.ToLower()).FirstOrDefault();
                Users ccUser = null;

                if (!string.IsNullOrWhiteSpace(emailDetails.Cc))
                {
                    ccUser = users.Where(x => x.UserName.ToLower() == emailDetails.Cc.ToLower()).FirstOrDefault();
                }
                if (toUser != null)
                {
                    EmailDetails objEmailDetails = new EmailDetails
                    {
                        To = toUser.UserId,
                        Cc = ccUser == null ? 0 : ccUser.UserId,
                        Subject = emailDetails.Subject,
                        Body = emailDetails.Body,
                        From = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                        IsAttachment = emailDetails.IsAttachment,
                        SentDateTime = DateTime.Now
                    };
                    appDbContext.EmailDetails.Add(objEmailDetails);
                    appDbContext.SaveChanges();

                    TempData["Message"] = "Email sent successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Invalid User - " + emailDetails.To;
                }

            }

            return View("ComposeEmail", emailDetails);
        }

    }
}
