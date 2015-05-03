using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.ViewModel.Group;
using WebApplication2.Models.ViewModel.Test;

namespace WebApplication2.Models.ViewModel
{
    public class TestGroupModel
    {
        public TestViewModel test { get; set; }
        public GroupsViewModel groups { get; set; }
    }
}