using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestioningSystem.Models;

namespace QuestioningSystem.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ApplicationUser Creator { get; set; }
        public int Duration { get; set; }
        public DateTime DateTime { get; set; }
        public  ICollection<Group> Groups { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }
        public Test()
        {
            Groups = new HashSet<Group>();
        }
    }
}