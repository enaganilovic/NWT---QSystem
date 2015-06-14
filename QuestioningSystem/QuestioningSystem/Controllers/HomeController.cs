using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestioningSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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
            ListOfNotificationViewModel list = new ListOfNotificationViewModel();
            list.Notifications = new List<NotificationViewModel>();

            using (var context = ApplicationDbContext.Create())
            {
                var notifications = context.Notifications.Where(x => x.Receiver.UserName == User.Identity.Name).Where(x => x.Activate == true).Include(x => x.Sender).Include(x => x.Group).Include(x => x.Test).ToList();
                foreach (var notification in notifications)
                {
                    NotificationViewModel model = new NotificationViewModel();
                    model.Datetime = notification.DateTime;
                    model.MessageText = notification.Message;
                    model.SenderUserName = notification.Sender.UserName;
                    model.NotificationID = notification.ID;
                    if (notification.Group != null)
                    {
                        model.GroupName = notification.Group.Title;
                        model.GroupId = notification.Group.ID;
                    }
                    if (notification.Test != null)
                    {
                        model.TestId = notification.Test.ID;
                        model.TestName = notification.Test.Title;
                    }
                    model.Type = notification.Type;
                    list.Notifications.Add(model);
                }
            }
            return View(list);
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

        public ActionResult AdminPanel()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            using (var context = ApplicationDbContext.Create())
            {
                users = context.Users.ToList();
            }
            return View(users);
        }

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