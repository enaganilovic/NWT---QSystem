using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestioningSystem.ViewModels;

namespace QuestioningSystem.Models
{
    public class CompletedTestViewModel
    {
        public string TestName { get; set; }
        public string TestID { get; set; }
        public string CompletedTestID { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateTime { get; set; }
        public List<QuestionAnswerPair> QuestionAnswerPairs { get; set; }
        public int NumberOfPoints { get; set; }
        public int MaxPoints { get; set; }

    }
}