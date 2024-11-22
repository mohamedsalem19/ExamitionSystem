namespace TaskExaminantionSystem.Models
{
    public class Student : BaseEntity
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
            StudentQuizzes = new List<StudentQuiz>();
            StudentAnswers = new List<StudentAnswer>();


        }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentQuiz> StudentQuizzes { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }

    }
}
