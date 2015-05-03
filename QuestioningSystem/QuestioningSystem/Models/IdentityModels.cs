using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace QuestioningSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public byte[] ProfilePicture { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ApplicationUser()
        {
            Groups = new HashSet<Group>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultContext")
        {
         
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Course> Coureses { get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<GroupTest> GroupTests { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<Archive> Arhive { get; set; }
        public DbSet<FinishedTests> FinishedTests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>().
            HasMany(c => c.Groups).
            WithMany(p => p.Members).
            Map(
            m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("GroupId");
                m.ToTable("User_Group");
            });

            builder.Entity<Test>().
          HasMany(c => c.Groups).
          WithMany(p => p.Tests).
          Map(
          m =>
          {
              m.MapLeftKey("TestId");
              m.MapRightKey("GroupId");
              m.ToTable("Test_Group");
          });

        }


    }
}   