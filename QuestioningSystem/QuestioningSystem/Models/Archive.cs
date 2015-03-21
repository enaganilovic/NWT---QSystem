using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestioningSystem.Models;

namespace QuestioningSystem.Models
{
    public class Archive
    {
        public int ID { get; set; }
        public ApplicationUser user { get; set; }
        public DateTime date { get; set; }
        public ApplicationUser mentor { get; set; }
        public Test test { get; set; }
        public float brojBodova { get; set; }
        public bool polozen { get; set; }

    }
}