namespace TaskExaminantionSystem.Models
{
    public class Instructor : BaseEntity
    {

        public Instructor()
        {
            Courses = new List<Course>();
            Quizzes = new List<Quiz>();
        }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
