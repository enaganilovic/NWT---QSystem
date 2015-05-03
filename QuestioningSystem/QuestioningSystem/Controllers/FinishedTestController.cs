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
    public class FinishedTestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/FinishedTest
        public IEnumerable<FinishedTests> GetFinishedTests()
        {
            var finishedtests = db.FinishedTests.Include(f => f.Question).Include(f => f.Test).Include(f => f.CorrectAnswer);
            return finishedtests.AsEnumerable();
        }

        // GET api/FinishedTest/5
        public FinishedTests GetFinishedTest(int id)
        {
            FinishedTests finishedtest = db.FinishedTests.Find(id);
            if (finishedtest == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return finishedtest;
        }

        // PUT api/FinishedTest/5
        public HttpResponseMessage PutFinishedTest(int id, FinishedTests finishedtest)
        {
            if (ModelState.IsValid && id == finishedtest.ID)
            {
                db.Entry(finishedtest).State = EntityState.Modified;

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

        // POST api/FinishedTest
        public HttpResponseMessage PostFinishedTest(FinishedTests finishedtest)
        {
            if (ModelState.IsValid)
            {
                db.FinishedTests.Add(finishedtest);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, finishedtest);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = finishedtest.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/FinishedTest/5
        public HttpResponseMessage DeleteFinishedTest(int id)
        {
            FinishedTests finishedtest = db.FinishedTests.Find(id);
            if (finishedtest == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.FinishedTests.Remove(finishedtest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, finishedtest);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}