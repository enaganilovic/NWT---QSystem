using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class CourseGroup
    {
        public int ID { get; set; }
        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; }
    }
}