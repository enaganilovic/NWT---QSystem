using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModel.Test
{
    public class CompletedTestViewModel
    {
        public string TestName { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateTime { get; set; }
        public List<QuestionAnswerPair> QuestionAnswerPairs { get; set; }
    }
}