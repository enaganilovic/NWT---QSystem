using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.ViewModels
{
    public class TestModel
    {
        public string TestName { get; set; }
        public int DurationTime { get; set; }
        public string DateTime { get; set; }
        public string Creator { get; set; }
        public int ID { get; set; }
        public List<QuestionAnswerPair> QuestionAnswerPairs { get; set; }
    }

    public class QuestionAnswerPair
    {
        public QuestionAnswerPair()
        {
            Answers = new List<QuestionAnswer>();
        }

        public string Question { get; set; }
        public int QuestionID { get; set; }
        public string UserAnswer { get; set; }
        public string Point { get; set; }
        public List<QuestionAnswer> Answers { get; set; }
    }

    public class QuestionAnswer
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
        public int AnswerId { get; set; }
    }
}