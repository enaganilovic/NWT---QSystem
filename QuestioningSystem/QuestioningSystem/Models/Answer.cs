using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public Question Question { get; set; }
    }
}