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
	}
}