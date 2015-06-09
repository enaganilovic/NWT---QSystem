using QuestioningSystem.Models;
using QuestioningSystem.Models.ViewModel.Group;
using QuestioningSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace QuestioningSystem.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestModel model)
        {
            Test test = new Test();

            using (var context = ApplicationDbContext.Create())
            {
                int testPoints = 0;
                var loggedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                test.Creator = loggedUser;
                test.Title = model.TestName;
                test.Duration = model.DurationTime;
                var dateTime = DateTime.ParseExact(model.DateTime, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                test.DateTime = dateTime;
                foreach (var q in model.QuestionAnswerPairs)
                {
                    var question = new Question();
                    question.Test = test;
                    question.Text = q.Question;
                    question.Points = Int32.Parse(q.Point);
                    testPoints += question.Points;
                    for (int i = 0; i < 4; i++)
                    {
                        var answer = new Answer
                        {
                            Text = q.Answers[i].Text,
                            Correct = q.Answers[i].IsChecked,
                            Question = question
                        };
                        context.Answers.Add(answer);
                    }
                    context.Questions.Add(question);
                }
                test.Active = false;
                test.Points = testPoints;
                context.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveTest(TestModel model)
        {
            // Test test = new Test();

            using (var context = ApplicationDbContext.Create())
            {
                var loggedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                var query = context.Tests.Where(x => x.ID == model.ID).FirstOrDefault();
                var questions = context.Questions.Where(x => x.Test.ID == query.ID).ToList();
                foreach (var question in questions)
                {
                    var answers = context.Answers.Where(x => x.Question.ID == question.ID).ToList();
                    foreach (var answer in answers)
                        context.Answers.Remove(answer);
                    context.Questions.Remove(question);
                }
                query.Creator = loggedUser;
                query.Title = model.TestName;
                query.Duration = model.DurationTime;
                string textQuestion = "";
                foreach (var q in model.QuestionAnswerPairs)
                {
                    if (q.Question != null)
                    {
                        textQuestion = q.Question;
                        continue;
                    }
                    var question = new Question
                    {
                        Test = query,
                        Text = textQuestion
                    };
                    for (int i = 0; i < 4; i++)
                    {
                        var answer = new Answer
                        {
                            Text = q.Answers[i].Text,
                            Correct = q.Answers[i].IsChecked,
                            Question = question
                        };
                        context.Answers.Add(answer);
                    }


                    context.Questions.Add(question);
                }

                context.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public PartialViewResult NewQuestion(int id)
        {
            id++;
            return PartialView("~/Views/Test/NewQuestion.cshtml", id);
        }

        public ActionResult Manage()
        {
            using (var context = ApplicationDbContext.Create())
            {
                var logedUser = context.Users.Where(x => x.UserName == User.Identity.Name).First();
                var query = context.Tests.Where(x => x.Creator.Id == logedUser.Id).ToList();
                ViewBag.TestNames = new SelectList(query, "ID", "Title", "Duration");
            }
            return View();
        }

        public ActionResult Delete(string passId)
        {
            int id = Int32.Parse(passId);
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Tests.Where(x => x.ID == id).First();
                var questions = context.Questions.Where(x => x.Test.ID == query.ID).ToList();

                foreach (var quest in questions)
                {
                    var answer = context.Answers.Where(x => x.Question.ID == quest.ID);
                }

                questions.Clear();
                context.Tests.Remove(query);
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult Edit(string passId)
        {
            TestModel test = new TestModel();
            int id = Int32.Parse(passId);
            List<QuestionAnswerPair> questionAnswerPairs = new List<QuestionAnswerPair>();
            // atributi 
            // public string Question { get; set; }
            // public List<QuestionAnswer> Answers { get; set; }
            using (var context = ApplicationDbContext.Create())
            {
                var tests = context.Tests.Where(x => x.ID == id).FirstOrDefault();
                DateTime timeTest = tests.DateTime;
                //DateTime oDate = DateTime.ParseExact(iString, "dd.mm.yyyy hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                int result = DateTime.Compare(timeTest, DateTime.Now);
                if (result > 0)
                {
                    test.TestName = tests.Title;
                    test.Creator = User.Identity.Name;
                    test.DurationTime = tests.Duration;
                    test.ID = tests.ID;
                    test.QuestionAnswerPairs = new List<QuestionAnswerPair>();
                    var questions = context.Questions.Where(x => x.Test.ID == tests.ID).ToList();
                    foreach (var question in questions)
                    {
                        var answers = context.Answers.Where(x => x.Question.ID == question.ID).ToList();
                        QuestionAnswerPair pair = new QuestionAnswerPair();

                        foreach (var answer in answers)
                        {
                            QuestionAnswer qA = new QuestionAnswer();
                            qA.Text = answer.Text;
                            qA.IsChecked = answer.Correct;
                            pair.Answers.Add(qA);
                        }
                        pair.Question = question.Text;
                        test.QuestionAnswerPairs.Add(pair);
                    }
                    return View(test);
                }
                return View("TestActive");
            }
        }

        public ActionResult ExploreTests()
        {
            GroupsForExploreTestList model = new GroupsForExploreTestList();
            model.lista = new List<GroupsForExploreTest>();

            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Tests.Where(x => x.Creator.UserName != User.Identity.Name).Include(x => x.Creator).ToList();
                foreach (var item in query)
                {
                    GroupsForExploreTest groups = new GroupsForExploreTest();
                    groups.Groups = new List<GroupIDTitleViewModel>();
                    groups.TestId = new int();
                    groups.TestName = "";
                    groups.Creator = "";
                    groups.TestId = item.ID;
                    groups.TestName = item.Title;
                    groups.Creator = item.Creator.UserName;
                    groups.DateTime = item.DateTime;
                    groups.Duration = item.Duration;
                    ICollection<Group> lista = item.Groups;
                    foreach (var group in lista)
                    {
                        GroupIDTitleViewModel groupIdTitle = new GroupIDTitleViewModel();
                        groupIdTitle.GroupId = group.ID;
                        groupIdTitle.GroupTitle = group.Title;
                        groups.Groups.Add(groupIdTitle);
                    }
                    model.lista.Add(groups);
                }
            }
            return View(model);
        }

      
	}
}