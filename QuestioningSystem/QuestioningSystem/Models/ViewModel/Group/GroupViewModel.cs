using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models.ViewModel.Group
{
    public class GroupViewModel
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public int ID { get; set; }
        public List<ApplicationUser> Members { get; set; }


        public int MaxNumberOfMembers { get; set; }
    }
}