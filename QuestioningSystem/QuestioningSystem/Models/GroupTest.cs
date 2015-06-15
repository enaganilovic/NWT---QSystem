using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class GroupTest
    {
        public int ID { get; set; }
        public Test Test { get; set; }
        public Group Group { get; set; }
    }
}