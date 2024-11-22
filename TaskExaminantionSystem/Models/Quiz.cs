using System.ComponentModel.DataAnnotations;
using TaskExaminantionSystem.Models.Enums;

namespace TaskExaminantionSystem.Models
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {
            QuizQuestions = new List<QuizQuestion>();
            StudentQuizzes = new List<StudentQuiz>();

        }
        public string Name { get; set; }
        [Range(0, 100)]

        public int Duration { get; set; }
        public ExamType ExamType { get; set; }
        public ExamLevel ExamLevel { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        public ICollection<StudentQuiz> StudentQuizzes { get; set; }

    }
}
