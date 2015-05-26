using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuestioningSystem.Models;

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
        public async Task<ActionResult> SaveGroup(GroupViewModel model)
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


	}
}