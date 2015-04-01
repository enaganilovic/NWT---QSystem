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
    public class CourseController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Course
        public IEnumerable<Course> GetCours()
        {
            var courses = db.Coureses;
            return courses.AsEnumerable();
        }

        // GET api/Course/5
        public Course GetCours(int id)
        {
            Course cours = db.Coureses.Find(id);
            if (cours == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cours;
        }

        // PUT api/Course/5
        public HttpResponseMessage PutCours(int id, Course cours)
        {
            if (ModelState.IsValid && id == cours.ID)
            {
                db.Entry(cours).State = EntityState.Modified;

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

        // POST api/Course
        public HttpResponseMessage PostCours(Course cours)
        {
            if (ModelState.IsValid)
            {
                db.Coureses.Add(cours);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cours);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cours.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Course/5
        public HttpResponseMessage DeleteCours(int id)
        {
            Course cours = db.Coureses.Find(id);
            if (cours == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Coureses.Remove(cours);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cours);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}