using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models
{
    public class FinishedTests
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
        public Answer CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public int NumberOfPoints { get; set; }
        public DateTime DateTime { get; set; }
    }
}