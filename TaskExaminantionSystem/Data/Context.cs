using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.Data
{
    public class Context : DbContext
    {

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer("server = .;DataBase = ExamSystem;Integrated security = true;trust server certificate = true")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information);
        }
    }
}
