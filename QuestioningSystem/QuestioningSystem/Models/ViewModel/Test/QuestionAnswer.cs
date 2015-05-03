using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModel.Test
{
    public class QuestionAnswer
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public String Answer1 { get; set; }
        public String Answer2 { get; set; }
        public String Answer3 { get; set; }
        public String Answer4 { get; set; }
        public int correctAnswer {get; set;}

    }
}