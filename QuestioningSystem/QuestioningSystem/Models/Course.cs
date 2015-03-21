using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestioningSystem.Models;

namespace QuestioningSystem.Models
{
    public class Course
    {
        public int ID { get; set; }
        public List<ApplicationUser> Owner { get; set; }
    }
}