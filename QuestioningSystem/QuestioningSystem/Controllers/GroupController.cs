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
    public class GroupController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET api/Group
        public IEnumerable<Group> GetGroups()
        {
            var groups = db.Groups;
            return groups.AsEnumerable();
        }

        // GET api/Group/5
        public Group GetGroup(int id)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return group;
        }

        // PUT api/Group/5
        public HttpResponseMessage PutGroup(int id, Group group)
        {
            if (ModelState.IsValid && id == group.ID)
            {
                db.Entry(group).State = EntityState.Modified;

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

        // POST api/Group
        public HttpResponseMessage PostGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, group);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = group.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Group/5
        public HttpResponseMessage DeleteGroup(int id)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Groups.Remove(group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}