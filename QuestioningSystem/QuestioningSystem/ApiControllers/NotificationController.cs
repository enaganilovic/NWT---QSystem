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
    public class NotificationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Notification
        public IEnumerable<Notification> GetNotifications()
        {
            var notifications = db.Notifications.Include(n => n.Receiver).Include(n => n.Sender).Include(n => n.Group).Include(n => n.Test);
            return notifications.AsEnumerable();
        }

        // GET api/Notification/5
        public Notification GetNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return notification;
        }

        // PUT api/Notification/5
        public HttpResponseMessage PutNotification(int id, Notification notification)
        {
            if (ModelState.IsValid && id == notification.ID)
            {
                db.Entry(notification).State = EntityState.Modified;

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

        // POST api/Notification
        public HttpResponseMessage PostNotification(Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, notification);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = notification.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Notification/5
        public HttpResponseMessage DeleteNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Notifications.Remove(notification);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, notification);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}