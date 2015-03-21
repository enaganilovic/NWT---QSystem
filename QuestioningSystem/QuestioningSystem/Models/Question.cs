using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class Question
    {
        public int ID { get; set; }
        public Test Test { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
    }
}