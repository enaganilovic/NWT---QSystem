using QuestioningSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestioningSystem.ApiControllers
{
    public class TestController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET api/Test
        public IEnumerable<Test> GetTests()
        {
            var tests = db.Tests;
            return tests.AsEnumerable();
        }

        // GET api/Default1/5
        public Test GetTest(int id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return test;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutTest(int id, Test test)
        {
            if (ModelState.IsValid && id == test.ID)
            {
                db.Entry(test).State = EntityState.Modified;

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

        // POST api/Default1
        public HttpResponseMessage PostTest(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, test);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = test.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteTest(int id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Tests.Remove(test);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, test);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}