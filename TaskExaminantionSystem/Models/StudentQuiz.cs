namespace TaskExaminantionSystem.Models
{
    public class StudentQuiz : BaseEntity
    {
        public int ExamResult { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
