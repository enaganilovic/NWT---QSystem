using QuestioningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestioningSystem.Controllers
{
    public class NotificationsController : Controller
    {
        //
        // GET: /Notification/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNotification(string CreatorName, string Type, string GroupId = "", string TestId = "")
        {
            int groupId = 0, testId = 0;
            if (GroupId != "")
                groupId = Int32.Parse(GroupId);
            if (TestId != "")
                testId = Int32.Parse(TestId);
            int type = Int32.Parse(Type);
            Notification notification = new Notification();
            using (var context = ApplicationDbContext.Create())
            {
                var sender = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                var receiver = context.Users.Where(x => x.UserName == CreatorName).First();
                if (GroupId != "" && groupId != 0)
                {
                    var group = context.Groups.Where(x => x.ID == groupId).First();
                    notification.Group = group;
                    notification.Message = "User " + User.Identity.Name + " want to join to your group " + group.Title + ".";
                    notification.Type = 1;
                }
                if (TestId != "" && testId != 0)
                {
                    var test = context.Tests.Where(x => x.ID == testId).First();
                    notification.Test = test;
                    notification.Message = "User " + User.Identity.Name + " sent you notification to create a group for your test " + test.Title + ".";
                    notification.Type = 2;
                }
                notification.Sender = sender;
                notification.Receiver = receiver;
                notification.Activate = true;
                notification.DateTime = DateTime.Now;
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
            return View();
        }

        public int NumberOfNewNotifications()
        {
            using (var context = ApplicationDbContext.Create())
            {
                var notifications = context.Notifications.Where(x => x.Receiver.UserName == User.Identity.Name).Where(x => x.Activate).ToList();
                return notifications.Count;
            }
            return 0;
        }
	}
}