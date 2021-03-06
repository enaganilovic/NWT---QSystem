﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestioningSystem.Models;


namespace QuestioningSystem.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ApplicationUser Creator { get; set; }
        public ICollection<ApplicationUser> Members { get; set; }
        public ICollection<Test> Tests { get; set; }
        public Group()
        {
            Members = new HashSet<ApplicationUser>();
            Tests = new HashSet<Test>();
        }
        public int MaxNumberOfMembers { get; set; }
        public DateTime CreationDate { get; set; }
    }
}