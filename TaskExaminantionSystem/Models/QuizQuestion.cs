namespace TaskExaminantionSystem.Models
{
    public class QuizQuestion : BaseEntity
    {
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}
