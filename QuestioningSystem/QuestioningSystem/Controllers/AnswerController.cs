using QuestioningSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestioningSystem.Controllers
{
    public class AnswerController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Answer
        public IEnumerable<Answer> GetAnswers()
        {
            var answers = db.Answers.Include(a => a.Question);
            return answers.AsEnumerable();
        }

        // GET api/Answer/5
        public Answer GetAnswer(int id)
        {
            Answer answer = db.Answers.Include(a => a.Question).FirstOrDefault(x => x.ID == id);
            if (answer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return answer;
        }

        // PUT api/Answer/5
        public HttpResponseMessage PutAnswer(int id, Answer answer)
        {
            if (ModelState.IsValid && id == answer.ID)
            {
                db.Entry(answer).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Answer
        public HttpResponseMessage PostAnswer(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, answer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = answer.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Answer/5
        public HttpResponseMessage DeleteAnswer(int id)
        {
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Answers.Remove(answer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}