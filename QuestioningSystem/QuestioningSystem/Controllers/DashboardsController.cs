using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using QuestioningSystem.Models;
using System.Data.Entity;

namespace QuestioningSystem.Controllers
{
    public class DashboardsController : Controller
    {
        //
        // GET: /Dashoboards/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Group()
        {
            return View();
        }

        public ActionResult GroupCreator()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> GetGroupChart()
        {
               using (var context = ApplicationDbContext.Create())
                {
                var data = context.Groups.Where(x => 1 == 1).Include(x=>x.Members).OrderByDescending(x=>x.Members.Count).ToList();
                List<string> titles = new List<string>();
                List<int> numbers = new List<int>();
                foreach (var item in data)
                {
                    titles.Add(item.Title);
                    numbers.Add(item.Members.Count);
                }
                var result = new { Titles = titles, Numbers = numbers };
                if (result != null)
                    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                   }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

       
        [HttpPost]
        public async Task<ActionResult> GetGroupCreatorChart()
        {
            ApplicationDbContext context = new ApplicationDbContext();
                List<string> usernames = new List<string>();
                List<int> numberOfGroups = new List<int>();
                var users = context.Users.Where(x => 1==1).ToList();
                foreach(var user in users)
                {
                    usernames.Add(user.UserName);
                    var groups = context.Groups.Where(x => x.Creator.UserName == user.UserName).ToList();
                    numberOfGroups.Add(groups.Count);
                }

                var result = new { Usernames = usernames, Numbers = numberOfGroups };
                if (result != null)
                    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> GetTestChart()
        {
            ApplicationDbContext context = new ApplicationDbContext();
                List<string> usernames = new List<string>();
                List<int> numberOfTests = new List<int>();
                var users = context.Users.Where(x => 1==1).ToList();
                foreach(var user in users)
                {
                    usernames.Add(user.UserName);
                    var tests = context.Tests.Where(x => x.Creator.UserName == user.UserName).ToList();
                    numberOfTests.Add(tests.Count);
                }

                var result = new { Usernames = usernames, Numbers = numberOfTests };
                if (result != null)
          return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

	}
}