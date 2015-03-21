using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class Notification
    {
        public  int ID { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public bool Activate { get; set; }
        public Group Group { get; set; }
        public Test Test { get; set; }

        //type of notification : 1.Join group, 2.Create group, 3.Message
        public int Type{ get; set; }
    }
}