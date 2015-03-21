using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class NotificationViewModel
    {
        public string SenderUserName { get; set; }
        public string MessageText { get; set; }
        public DateTime Datetime { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public string TestName { get; set; }
        public int TestId { get; set; }
        // Type 1 - Notifications with accept and rejecet buttons , 2 - Notifications with OK button, and message.
        public int Type { get; set; }
        public int NotificationID { get; set; }
    }
}