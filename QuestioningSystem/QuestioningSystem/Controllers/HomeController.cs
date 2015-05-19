using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestioningSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace QuestioningSystem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AdminPanel()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            using (var context = ApplicationDbContext.Create())
            {
                users = context.Users.ToList();
            }
            return View(users);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Ban(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    user.Banned = true;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("AdminPanel");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UnBan(string id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    user.Banned = false;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("AdminPanel");
        }



    }
}