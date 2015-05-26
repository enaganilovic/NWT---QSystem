using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using QuestioningSystem.Models;

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


        [HttpPost]
        public async Task<ActionResult> GetGroupChart()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var data =  context.Groups.Where(x => x.Creator.Id == user.Id).ToList();
            if (data != null)
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };    
            
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
	}
}