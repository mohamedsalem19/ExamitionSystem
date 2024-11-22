namespace TaskExaminantionSystem.Models
{
    public class Course : BaseEntity
    {

        public Course()
        {
            StudentCourses = new List<StudentCourse>();
            Quizzes = new List<Quiz>();
        }
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }


    }
}
