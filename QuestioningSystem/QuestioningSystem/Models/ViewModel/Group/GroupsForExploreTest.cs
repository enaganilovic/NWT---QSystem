using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestioningSystem.Models.ViewModel.Group
{
    public class GroupsForExploreTest
    {
        public List<GroupIDTitleViewModel> Groups { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string Creator { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
    }
}