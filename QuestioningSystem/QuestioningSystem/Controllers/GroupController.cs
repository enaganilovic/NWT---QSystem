using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuestioningSystem.Models;
using QuestioningSystem.Models.ViewModel.Group;

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

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveGroup(QuestioningSystem.Models.ViewModel.Group.GroupViewModel model)
        {
            var group = new Group();
            if (model != null)
            {
                using (var context = ApplicationDbContext.Create())
                {
                    if (!string.IsNullOrWhiteSpace(User.Identity.Name))
                    group.Creator.UserName = User.Identity.Name;
                    group.MaxNumberOfMembers = model.MaxNumberOfMembers;
                    group.Title = model.Title;
                    group.CreationDate = DateTime.Now;
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


	}
}