using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class GroupTest
    {
        public int ID { get; set; }
        public List<Test> Tests { get; set; }
        public List<Group> Groups { get; set; }
    }
}