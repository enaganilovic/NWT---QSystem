using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuestioningSystem.Models;
using QuestioningSystem.Models.ViewModel.Group;
using QuestioningSystem.Models.ViewModel;
using System.Data.Entity;

namespace QuestioningSystem.Controllers
{
    public class GroupController : Controller
    {
        //
        // GET: /Group/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CheckUser(string userName)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var users = context.Users.Where(x => x.UserName == userName).ToList();
                if (users.Count != 0)
                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveGroup(QuestioningSystem.Models.ViewModel.Group.GroupViewModel model)
        {
            var group = new Group();
            List<ApplicationUser> users = new List<ApplicationUser>();
            if (model != null && model.Title != null && model.MaxNumberOfMembers > 0)
            {
                using (var context = ApplicationDbContext.Create())
                {
                    if (!string.IsNullOrWhiteSpace(User.Identity.Name)) {
                         var user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                         group.Creator = user;
                    }
                    group.MaxNumberOfMembers = model.MaxNumberOfMembers;
                    group.Title = model.Title;
                    group.CreationDate = DateTime.Now;
                    if (!string.IsNullOrWhiteSpace(model.GroupMember))
                    {
                        if (model.GroupMember.Contains(';'))
                        {
                            string[] nameLines = model.GroupMember.Split(';');
                            foreach (var item in nameLines)
                            {
                                var user = context.Users.Where(x => x.UserName == item).FirstOrDefault();
                                if (user != null)
                                {
                                    users.Add(user);
                                    group.Members.Add(user);
                                }
                            }
                        }
                        else
                        {
                            var user = context.Users.Where(x => x.UserName == model.GroupMember).FirstOrDefault();
                            if (user != null)
                            {
                                users.Add(user);
                            }
                        }
                        group.Members = users;
                    }
                    context.Groups.Add(group);
                    context.SaveChanges();
                }
                return new JsonResult { Data = group, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
                return new JsonResult { Data = "Could not save group.", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        [Authorize]
        public ActionResult SaveChanges(string title, int maxNumber, int passId)
        {
            QuestioningSystem.Models.ViewModel.Group.GroupViewModel newGroup = new QuestioningSystem.Models.ViewModel.Group.GroupViewModel();
            using (var context = ApplicationDbContext.Create())
            {
                var oldGroup = context.Groups.Where(x => x.ID == passId).First();
                //string[] nameLines = namesOfUsers.Split(',');
                //foreach (var username in nameLines)
                //{
                //    if (username == "") continue;
                //    var user = context.Users.Where(x => x.UserName == username).First();
                //    users.Add(user);
                //}
                //oldGroup.Members.Clear();
                //oldGroup.Members = users;
                oldGroup.Title = title;
                oldGroup.MaxNumberOfMembers = maxNumber;
                oldGroup.ID = passId;
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllData()
        {
            using (var context = ApplicationDbContext.Create())
            {
                var groups = (from g in context.Groups
                              select g).ToList();

                return new JsonResult { Data = groups, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
            }

        }


        public ActionResult Edit(int Id)
        {
            QuestioningSystem.Models.ViewModel.Group.GroupViewModel group = new QuestioningSystem.Models.ViewModel.Group.GroupViewModel();
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Groups.Where(x => x.ID == Id).FirstOrDefault();
                if (query != null)
                {
                    group.Title = query.Title;
                    group.MaxNumberOfMembers = query.MaxNumberOfMembers;
                    group.ID = Id;
                }
            }
            return View(group);
        }

        public ActionResult Delete(int Id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Groups.Where(x => x.ID == Id).First();
                query.Members.Clear();
                context.Groups.Remove(query);
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult ViewAllMembers(int Id, string userId = "")
        {
            QuestioningSystem.Models.ViewModel.Group.GroupViewModel model = new QuestioningSystem.Models.ViewModel.Group.GroupViewModel();
            model.Members = new List<ApplicationUser>();
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Groups.Where(x => x.ID == Id).Include(x => x.Members).FirstOrDefault();
                var members = query.Members;
               
                if (!String.IsNullOrEmpty(userId))
                {
                    var userToDelete = context.Users.Where(x => x.Id == userId).FirstOrDefault();
                    members.Remove(userToDelete);
                    context.SaveChanges();
                }
                    foreach (var member in members)
                    {
                        model.Members.Add(member);
                    }
                    model.ID = query.ID;
                    model.Title = query.Title;
                    model.Creator = User.Identity.Name;
            }
            return View(model);
        }

        public ActionResult AssignToTest(string passId)
        {
            
            TestGroupModel model = new TestGroupModel();
            model.groups = new GroupsViewModel();
            model.groups.Groups = new List<QuestioningSystem.Models.ViewModel.Group.GroupViewModel>();
             model.test = new TestViewModel()
            {
                ID = Int32.Parse(passId)
            };
            using (var context = ApplicationDbContext.Create())
            {
                var logedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                var query = context.Groups.Where(x => x.Creator.Id == logedUser.Id).ToList();
                foreach (var item in query)
                {
                    model.groups.Groups.Add(new Models.ViewModel.Group.GroupViewModel
                    {
                        ID = item.ID,
                        Title = item.Title
                    });
                }
            }
            return PartialView("~/Views/Group/AssignToTest.cshtml", model);
        }

        [HttpPost]
        public void AddUser(string groupid, string username, string notificationid)
        {
            using (var context = ApplicationDbContext.Create())
            {
                int groupID = Int32.Parse(groupid);
                int notificationID = Int32.Parse(notificationid);
                var group = context.Groups.Where(x => x.ID == groupID).First();
                var user = context.Users.Where(x => x.UserName == username).First();
                var activeNotication = context.Notifications.Where(x => x.ID == notificationID).First();
                activeNotication.Activate = false;
                var logedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                group.Members.Add(user);
                string notificationText = "User " + User.Identity.Name + " add you to the group " + group.Title + ".";
                Notification notification = new Notification();
                notification.Type = 3;
                notification.Activate = true;
                notification.DateTime = DateTime.Now;
                notification.Group = group;
                notification.Message = notificationText;
                notification.Sender = logedUser;
                notification.Receiver = user;
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }

        public ActionResult Manage()
        {
            GroupListViewModel groups = new GroupListViewModel();
            groups.Groups = new List<Models.ViewModel.Group.GroupViewModel>();
            using (var context = ApplicationDbContext.Create())
            {
                var loggedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                if (loggedUser != null)
                {
                    var query = context.Groups.Where(x => x.Creator.Id == loggedUser.Id).ToList();
                    foreach (var item in query)
                    {
                        QuestioningSystem.Models.ViewModel.Group.GroupViewModel group = new QuestioningSystem.Models.ViewModel.Group.GroupViewModel();
                        group.ID = item.ID;
                        group.Creator = item.Creator.UserName;
                        group.MaxNumberOfMembers = item.MaxNumberOfMembers;
                        group.Title = item.Title;
                        groups.Groups.Add(group);
                    }
                 }
                return View(groups);
            }
        }

        [HttpPost]
        public void Ok(string notificationid)
        {
            int notificationID = Int32.Parse(notificationid);
            using (var context = ApplicationDbContext.Create())
            {
                var activeNotication = context.Notifications.Where(x => x.ID == notificationID).First();
                activeNotication.Activate = false;
                context.SaveChanges();
            }
        }


        public void DeclineUser(string groupid, string username, string notificationid)
        {
            using (var context = ApplicationDbContext.Create())
            {
                int groupID = Int32.Parse(groupid);
                int notificationID = Int32.Parse(notificationid);
                var group = context.Groups.Where(x => x.ID == groupID).First();
                var user = context.Users.Where(x => x.UserName == username).First();
                var activeNotication = context.Notifications.Where(x => x.ID == notificationID).First();
                activeNotication.Activate = false;
                var logedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                group.Members.Add(user);
                string notificationText = "User " + User.Identity.Name + " decline your request to join group " + group.Title + ".";
                Notification notification = new Notification();
                notification.Type = 3;
                notification.Activate = true;
                notification.DateTime = DateTime.Now;
                notification.Group = group;
                notification.Message = notificationText;
                notification.Sender = logedUser;
                notification.Receiver = user;
                context.Notifications.Add(notification);
                context.SaveChanges();
            }
        }


        public ActionResult Assign(string groupId, string testId)
        {
            GroupTest groupTest = new GroupTest();
            AssignTestGroup model = new AssignTestGroup();
            using (var context = ApplicationDbContext.Create())
            {
                var grId = Int32.Parse(groupId);
                var tId = Int32.Parse(testId);
                var logedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                var group = context.Groups.Where(x => x.ID == grId).First();
                var test = context.Tests.Where(x => x.ID == tId).First();
                group.Tests.Add(test);
                test.Groups.Add(group);
                context.SaveChanges();
            }
            return View(model);
        }
	}
}