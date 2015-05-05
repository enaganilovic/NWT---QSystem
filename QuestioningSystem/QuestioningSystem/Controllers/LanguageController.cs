using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace QuestioningSystem.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult SetLanguage(string name)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Session["CurrentLanguage"] = name;

            return RedirectToAction("Index", "Home");
        }
    }
}